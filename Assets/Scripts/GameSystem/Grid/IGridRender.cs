using HomeWork.GameSystem;
using UnityEngine;

public interface IGridRender
{
    /// <summary>
    /// ��l�Ʈ�l��V��
    /// </summary>
    void Initialize();

    /// <summary>
    /// �إ߾�����d����l���ϡC
    /// </summary>
    void CreateGridViews(LevelData levelData, Vector3 startPointPosition);

    /// <summary>
    /// �w���@��l�̷Ө� Type ��s�C��C
    /// </summary>
    void RefreshTile(Vector2 coord);

    /// <summary>
    /// �M�����k�٩Ҧ���l���ϡC
    /// </summary>
    void ReleaseGridViews();
}
