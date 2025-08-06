using System.Collections.Generic;
using UnityEngine;
using HomeWork.GameInput;

namespace HomeWork.GameSystem
{
    public class CuboidBlock :
        IBlockLogic
    {
        private  Dictionary<BlockState, IBlockStateStrategy> _stateStrategies;
        private  List<Vector2> _currentPositions;
        private BlockState _blockState;

        /// <summary>
        /// 初始化，但尚未設置初始位置（請呼叫 SetState）。
        /// </summary>
        public CuboidBlock()
        {
            _stateStrategies = new Dictionary<BlockState, IBlockStateStrategy>
            {
                [BlockState.Stand] = new StandStateStrategy(),
                [BlockState.LieHorizontal] = new LieHorizontalStrategy(),
                [BlockState.LieVerticle] = new LieVerticalStrategy(),
            };
            _currentPositions = new List<Vector2>();
        }
        public void Move(InputDirection direction)
        {
            EnsureInitialized();
            IBlockStateStrategy strategy = GetStrategy(_blockState);
            var nextPositions = strategy.CalculatePosition(_currentPositions, direction, out var nextState);
            SetState(nextPositions[0], nextState);
        }
        public List<Vector2> GetCurrentPosition()
        { 
            return new List<Vector2>(_currentPositions);
        }

        public BlockState GetBlockState()
        { 
            return _blockState;
        }
        
        public List<Vector2> CaculateMove(InputDirection direction, out BlockState nextState)
        {
            EnsureInitialized();
            IBlockStateStrategy strategy = GetStrategy(_blockState);
            var positions = strategy.CalculatePosition(_currentPositions, direction, out nextState);
            return new List<Vector2>(positions);
        }

        public void SetState(Vector2 anchor, BlockState newState)
        {
            _currentPositions.Clear();
            switch (newState)
            {
                case BlockState.Stand:
                    _currentPositions.Add(anchor);
                    _currentPositions.Add(anchor);
                    break;

                case BlockState.LieHorizontal:
                    _currentPositions.Add(anchor);
                    _currentPositions.Add(new Vector2(anchor.x + 1, anchor.y));
                    break;

                case BlockState.LieVerticle:
                    _currentPositions.Add(anchor);
                    _currentPositions.Add(new Vector2(anchor.x, anchor.y + 1));
                    break;

                default:
                    Debug.LogError($"{nameof(CuboidBlock)}未知的 BlockState：{newState}");
                    break;
            }

            _blockState = newState;
        }
        private IBlockStateStrategy GetStrategy(BlockState blockState)
        {
            if (!_stateStrategies.TryGetValue(_blockState, out var strategy))
            {
                Debug.LogError($"{nameof(CuboidBlock)}未支援的 BlockState：{_blockState}，使用Stand策略替代");
                return _stateStrategies[BlockState.Stand];
            }
            return strategy;
        }
        private void EnsureInitialized()
        {
            if (_currentPositions.Count == 0)
            {
                Debug.LogError($"{nameof(CuboidBlock)}請先以 SetState 初始化位置與狀態。");
            }
        }
    }
}
