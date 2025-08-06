using System.Collections.Generic;
using UnityEngine;
using HomeWork.GameInput;
namespace HomeWork.GameSystem
{

    public class LieHorizontalStrategy : IBlockStateStrategy
    {
        private readonly Dictionary<InputDirection, (List<Vector2> newPos, BlockState state)> _nextState;
        public LieHorizontalStrategy()
        {
            _nextState = new Dictionary<InputDirection, (List<Vector2> newPos, BlockState state)>
        {
            { InputDirection.Up, (new  List<Vector2> { Vector2.up, Vector2.up }, BlockState.LieHorizontal ) },
            { InputDirection.Down, (new  List<Vector2> { Vector2.down, Vector2.down }, BlockState.LieHorizontal ) },
            { InputDirection.Left, (new  List<Vector2> { Vector2.left, Vector2.left*2 }, BlockState.Stand ) },
            { InputDirection.Right, (new  List<Vector2> { Vector2.right*2, Vector2.right }, BlockState.Stand ) },
        };
        }
        public List<Vector2> CalculatePosition(List<Vector2> currentPosition, InputDirection direction, out BlockState nextState)
        {
            if (currentPosition.Count < 2) 
            {
                Debug.LogError($"{nameof(LieHorizontalStrategy)}輸入的位置數量不對");
                nextState = default;
                return new List<Vector2>();
            }

            var result = new List<Vector2>();
            nextState = BlockState.Stand;
            (Vector2 pos1, Vector2 pos2) reult;

            var value = _nextState.GetValueOrDefault(direction);
            reult = (currentPosition[0] + value.newPos[0], currentPosition[1] + value.newPos[1]);
            nextState = value.state;
            result.Add(reult.pos1);
            result.Add(reult.pos2);
            return result;
        }
    }
}