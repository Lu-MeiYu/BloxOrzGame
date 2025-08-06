using HomeWork.GameSystem;
using UnityEngine;

public interface IGridRender
{
    /// <summary>
    /// 初始化格子渲染器
    /// </summary>
    void Initialize();

    /// <summary>
    /// 建立整個關卡的格子視圖。
    /// </summary>
    void CreateGridViews(LevelData levelData, Vector3 startPointPosition);

    /// <summary>
    /// 針對單一格子依照其 Type 更新顏色。
    /// </summary>
    void RefreshTile(Vector2 coord);

    /// <summary>
    /// 清除並歸還所有格子視圖。
    /// </summary>
    void ReleaseGridViews();
}
