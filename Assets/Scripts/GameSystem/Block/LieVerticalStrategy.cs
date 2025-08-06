using System.Collections.Generic;
using UnityEngine;
using HomeWork.GameInput;
namespace HomeWork.GameSystem
{
    public class LieVerticalStrategy : IBlockStateStrategy
    {
        private readonly Dictionary<InputDirection, (List<Vector2> newPos, BlockState state)> _nextState;
        public LieVerticalStrategy()
        {
            _nextState = new Dictionary<InputDirection, (List<Vector2> newPos, BlockState state)>
        {
            { InputDirection.Up, (new  List<Vector2> { Vector2.up*2, Vector2.up }, BlockState.Stand ) },
            { InputDirection.Down, (new  List<Vector2> { Vector2.down, Vector2.down*2 }, BlockState.Stand ) },
            { InputDirection.Left, (new  List<Vector2> { Vector2.left, Vector2.left }, BlockState.LieVerticle ) },
            { InputDirection.Right, (new  List<Vector2> { Vector2.right, Vector2.right }, BlockState.LieVerticle ) },
        };
        }
        public List<Vector2> CalculatePosition(List<Vector2> currentPosition, InputDirection direction, out BlockState nextState)
        {
            if (currentPosition.Count < 2)
            {
                Debug.LogError($"{nameof(LieVerticalStrategy)}輸入的位置數量不對");
                nextState = default;
                return new List<Vector2>();
            }
            var result = new List<Vector2>();
            nextState = BlockState.Stand;
            (Vector2 pos1, Vector2 pos2) reult;

            var value = _nextState.GetValueOrDefault(direction);
            reult = (currentPosition[0] + value.newPos[0], (currentPosition[1] + value.newPos[1]));
            nextState = value.state;
            result.Add(reult.pos1);
            result.Add(reult.pos2);
            return result;
        }
    }
}
