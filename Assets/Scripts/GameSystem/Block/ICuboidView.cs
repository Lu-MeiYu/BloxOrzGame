using HomeWork.GameInput;
using UnityEngine;
using System;

public interface ICuboidView 
{
    /// <summary>
    /// 合法移動動畫播放完畢後執行的事件
    /// </summary>
    public event Action OnFinishLegalAnimation;

    /// <summary>
    /// 非法移動動畫播放完畢後執行的事件
    /// </summary>
    public event Action OnFinishIllegalAnimtion;

    /// <summary>
    /// 將Cuboid放置指定位置並初始化狀態上
    /// </summary>
    /// <param name="startPointWorldPosition">起始位置</param>
    public void Initialize(Vector3 startPointWorldPosition);

    /// <summary>
    /// 撥放合法移動時的動畫
    /// </summary>
    /// <param name="direction">輸入的方向</param>
    /// <param name="blockState">當前狀態</param>
    public void DisplayLegalMove(InputDirection direction, BlockState blockState);

    /// <summary>
    /// 撥放非法移動時的動畫
    /// </summary>
    /// <param name="direction">輸入的方向</param>
    /// <param name="blockState">當前狀態</param>
    public void DisplayIllegalMove(InputDirection direction, BlockState blockState);
}
