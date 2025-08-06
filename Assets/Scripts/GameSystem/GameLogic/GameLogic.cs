using System.Collections.Generic;
using System.Linq;
using HomeWork.GameInput;
using UnityEngine;
namespace HomeWork.GameSystem
{
    public class GameLogic :
        IGameLogic
    {
        private readonly IBlockLogic _blockLogic;
        private LevelData _levelData;

        /// <summary>
        /// 初始化，但尚未設置遊戲資訊(請呼叫SetGame)
        /// </summary>
        /// <param name="blockLogic"></param>
        public GameLogic(IBlockLogic blockLogic)
        {
            if (blockLogic == null) 
            {
                Debug.LogError($"{nameof(GameLogic)}blockLogic不可為null!");
            }
            _blockLogic = blockLogic;
        }
        public void SetGame(LevelData levelData)
        {
            if (levelData == null) 
            {
                Debug.LogError($"{nameof(GameLogic)}不可為null!");
                return;
            }
            _levelData = levelData;
            _blockLogic.SetState(_levelData.StartPoint, BlockState.Stand);
        }
        public void MoveBlock(InputDirection direction)
        {
            EnsureInitialized();
            _blockLogic.Move(direction);
        }
        public List<Vector2> GetBlockState(out BlockState blockState)
        {
            EnsureInitialized();
            blockState = _blockLogic.GetBlockState();
            return _blockLogic.GetCurrentPosition();
        }
        public bool IsValidMove(InputDirection direction)
        {
            EnsureInitialized();
            var nextPositions = _blockLogic.CaculateMove(direction, out _);
            return nextPositions.All(pos => _levelData.Tiles.Contains(pos));
        }
        public bool IsWin()
        {
            EnsureInitialized();
            return (_blockLogic.GetBlockState() == BlockState.Stand)
                && (_blockLogic.GetCurrentPosition().All(pos => pos == _levelData.EndPoint));
        }
        private void EnsureInitialized()
        {
            if (_levelData == null)
            {
                Debug.LogError($"{nameof(GameLogic)}請先呼叫SetGame設置資料");
            }
        }
    }
}
