using System.Collections;
using System.Collections.Generic;
using HomeWork.GameInput;
using HomeWork.GameSystem;
using UnityEngine;

public interface IPathFinder
{
    /// <summary>
    /// 若找到路徑回傳 true，並透過 out 參數回傳路徑列表。
    /// </summary>
    public bool FindPath(out List<InputDirection> path);

    /// <summary>
    /// 設定關卡資料
    /// </summary>
    public void SetData(LevelData levelData);
}
