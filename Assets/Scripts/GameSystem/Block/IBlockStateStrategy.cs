using System.Collections.Generic;
using UnityEngine;
using HomeWork.GameInput;

namespace HomeWork.GameSystem
{
    /// <summary>
    /// �ھ�Block��e���A�PInput��V�p�Ⲿ�ʫ᪺��m�P���A
    /// </summary>
    public interface IBlockStateStrategy
    {
        List<Vector2> CalculatePosition(List<Vector2> currentPosition, InputDirection direction, out BlockState nextState);
    }
}