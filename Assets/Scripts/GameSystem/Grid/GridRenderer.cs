using System.Collections.Generic;
using UnityEngine;
using HomeWork.GameSystem;
using HomeWork.ObjectPool;
public class GridRenderer : MonoBehaviour,
    IGridRender
{
    [SerializeField] private Color _occupiedPointColor;
    [SerializeField] private Color _startColor;
    [SerializeField] private Color _endColor;
    [SerializeField] private Color _normalColor;
    [SerializeField] private int _tileViewInitCount;
    [SerializeField] private TileView _tilePrefab;

    private  Dictionary<Vector2, TileView> _gridViews;
    private  Dictionary<TileType, Color> _tileColors;
    private  ObjectPool<TileView> _tilePool;

    /// <summary>
    /// 初始化，但尚未創建地磚(請呼叫CreateGridView)
    /// </summary>
    public void Initialize()
    {
        CheckSetting();
        _tilePool = ObjectPoolManager.Instance.GetOrCreatePool<TileView>(_tilePrefab, _tileViewInitCount,transform);
         _gridViews = new();
        _tileColors = new();
        _tileColors[TileType.BeginPoint] = _startColor;
        _tileColors[TileType.EndPoint] = _endColor;
        _tileColors[TileType.Default] = _normalColor;
    }

    public void CreateGridViews(LevelData levelData, Vector3 startPointPosition)
    {
        if (_tilePool == null)
        {
            Debug.LogError($"{nameof(GridRenderer)}必須先呼叫 SetGame() 設定 TileView Pool");
        }
        if (levelData?.Tiles == null)
        {
            Debug.LogError($"{nameof(LevelData)}LevelData 或 tiles 為 null");
        }

        ReleaseGridViews();

        foreach (Vector2 coord in levelData.Tiles)
        {
            var view = _tilePool.Get();
            float halfHeight = view.transform.lossyScale.y * 0.5f;
            view.transform.position = startPointPosition + new Vector3(coord.x, -halfHeight, coord.y);
            view.Type = TileType.Default;
            _gridViews[coord] = view;
            RefreshTile(coord);
        }
        SetTileType(levelData.StartPoint, TileType.BeginPoint);
        SetTileType(levelData.EndPoint, TileType.EndPoint);
    }

    public void RefreshTile(Vector2 coord)
    {
        if (!_gridViews.TryGetValue(coord, out var view))
        {
            Debug.LogError($"{nameof(GridRenderer)}找不到座標 {coord} 的 TileView");
            return;
        }

        if (!_tileColors.TryGetValue(view.Type, out var color))
        {
            Debug.LogError($"{nameof(GridRenderer)}未定義 TileType {view.Type} 的顏色");
            return;
        }

        view.SetColor(color);
    }
    public void ReleaseGridViews()
    {
        foreach (var view in _gridViews.Values)
        {
            _tilePool.Return(view);
        }
        _gridViews.Clear();
    }
    private void SetTileType(Vector2 coord, TileType type)
    {
        if (_gridViews.TryGetValue(coord, out var view))
        {
            view.Type = type;
            RefreshTile(coord);
        }
        else
        {
            Debug.LogError($"{nameof(GridRenderer)}無法設定 TileType，找不到座標 {coord}");
        }
    }
    private void CheckSetting()
    {
        if (_tilePrefab == null) 
        {
            Debug.LogError($"{name} tilePrefab不可為null!");
        }
        if (_tileViewInitCount < 0)
        {
            Debug.LogWarning($"{name} tileViewInitCount 小於0!");
        }
    }
}