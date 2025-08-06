using System.Collections.Generic;
using UnityEngine;
using HomeWork.GameInput;

namespace HomeWork.GameSystem
{
    /// <summary>
    /// 根據Block當前狀態與Input方向計算移動後的位置與狀態
    /// </summary>
    public interface IBlockStateStrategy
    {
        List<Vector2> CalculatePosition(List<Vector2> currentPosition, InputDirection direction, out BlockState nextState);
    }
}