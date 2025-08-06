using UnityEngine;
using System;
using HomeWork.GameInput;

namespace HomeWork.GameSystem
{
    /// <summary>
    /// 管理遊戲核心類別
    /// </summary>
    public class GameHandler
    {
        /// <summary>當一次合法滾動動畫結束後觸發</summary>
        public event Action OnValidMoveCompleted;

        /// <summary>當一次非法滾動（回滾）動畫結束後觸發</summary>
        public event Action OnInValidMoveCompleted;

        private LevelDataManager _levelDataManager;

        private IGameLogic _gamePlay;
        private IGridRender _gridRender;
        private ICuboidView _blockView;
        private LevelData _currentLevelData;

        public int MaxLevel => _levelDataManager.MaxCount;

        public int CurrentLevel { get; private set; }

        public bool IsInAnimation { get; private set; }

        public int MoveCount { get; private set; }

        public bool IsWin => _gamePlay.IsWin();

        public GameHandler(IGridRender gridRenderer, ICuboidView cuboidController, LevelDataManager levelDataManager, IGameLogic gameLogic)
        {
            _gamePlay = gameLogic;
            _gridRender = gridRenderer;
            _levelDataManager = levelDataManager;
            _blockView = cuboidController;

            CheckSetting();

            _blockView.OnFinishLegalAnimation += HandleRollComplete;
            _blockView.OnFinishIllegalAnimtion += HandleDisplayComplete;
        }

        /// <summary>
        /// 清除目前遊戲畫面與步數（準備重新開始或切換關卡）。
        /// </summary>
        public void ClearCurrentGame()
        {
            _gridRender.ReleaseGridViews();
            MoveCount = 0;
        }

        /// <summary>
        /// 設定並開始第 <paramref name="level"/> 關。
        /// </summary>
        /// <param name="level">欲啟動的關卡號碼（從 1 開始）</param>
        public void SetLevel(int level)
        {
            if (_currentLevelData != null) 
            {
                GameObject.Destroy(_currentLevelData);
            }

            _currentLevelData = _levelDataManager.GetRunTimeLevelData(level);

            if (_currentLevelData == null)
            {
                Debug.LogError($"{nameof(GameHandler)}關卡資料為null!");
                return;
            }
            CurrentLevel = level;
            SetupLevel(_currentLevelData, Vector3.zero);
        }

        /// <summary>
        /// 判斷指定移動方向 <paramref name="inputDirection"/> 是否為合法移動。
        /// </summary>
        /// <param name="inputDirection">欲檢查的移動方向</param>
        /// <returns>合法回傳 true，否則 false</returns>
        public bool IsValidMove(InputDirection inputDirection)
        {
            return _gamePlay != null && _gamePlay.IsValidMove(inputDirection);
        }

        /// <summary>
        /// 執行一次合法移動：播放滾動動畫並更新邏輯與步數。
        /// </summary>
        /// <param name="inputDirection">移動方向</param>
        public void ValidMove(InputDirection inputDirection)
        {
            var positions = _gamePlay.GetBlockState(out BlockState blockState);
            _blockView.DisplayLegalMove(inputDirection, blockState);
            _gamePlay.MoveBlock(inputDirection);

            MoveCount++;
            IsInAnimation = true;
        }

        /// <summary>
        /// 執行一次非法移動：播放回滾動畫（提示錯誤）。
        /// </summary>
        /// <param name="inputDirection">嘗試的移動方向</param>
        public void InValidMove(InputDirection inputDirection)
        {
            var positions = _gamePlay.GetBlockState(out BlockState blockState);
            _blockView.DisplayIllegalMove(inputDirection, blockState);

            IsInAnimation = true;
        }
        private void CheckSetting()
        {
            if (_gridRender == null)
            {
                Debug.LogError($"{nameof(GameHandler)}: _gridRender 未設定！");
            }
            if (_blockView == null)
            {
                Debug.LogError($"{nameof(GameHandler)}: _blockView 未設定！");
            }
            if (_levelDataManager == null)
            {
                Debug.LogError($"{nameof(GameHandler)}: levelDatas 未設定！");
            }
        }

        private void SetupLevel(LevelData levelData, Vector3 startPosition)
        {
            _gamePlay.SetGame(levelData);
            Vector3 position = startPosition
                                 + Vector3.forward * levelData.StartPoint.y
                                 + Vector3.right * levelData.StartPoint.x;

            _blockView.Initialize(position);

            _gridRender.CreateGridViews(levelData, startPosition);
            IsInAnimation = false;

            foreach (var tile in levelData.Tiles)
            {
                _gridRender.RefreshTile(tile);
            }
        }
        private void HandleRollComplete()
        {
            IsInAnimation = false;
            OnValidMoveCompleted?.Invoke();
        }

        private void HandleDisplayComplete()
        {
            IsInAnimation = false;
            OnInValidMoveCompleted?.Invoke();
        }
    }
}
