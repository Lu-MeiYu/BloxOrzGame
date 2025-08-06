using UnityEngine;
using System;
using HomeWork.GameInput;

namespace HomeWork.GameSystem
{
    /// <summary>
    /// �޲z�C���֤����O
    /// </summary>
    public class GameHandler
    {
        /// <summary>��@���X�k�u�ʰʵe������Ĳ�o</summary>
        public event Action OnValidMoveCompleted;

        /// <summary>��@���D�k�u�ʡ]�^�u�^�ʵe������Ĳ�o</summary>
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
        /// �M���ثe�C���e���P�B�ơ]�ǳƭ��s�}�l�Τ������d�^�C
        /// </summary>
        public void ClearCurrentGame()
        {
            _gridRender.ReleaseGridViews();
            MoveCount = 0;
        }

        /// <summary>
        /// �]�w�ö}�l�� <paramref name="level"/> ���C
        /// </summary>
        /// <param name="level">���Ұʪ����d���X�]�q 1 �}�l�^</param>
        public void SetLevel(int level)
        {
            if (_currentLevelData != null) 
            {
                GameObject.Destroy(_currentLevelData);
            }

            _currentLevelData = _levelDataManager.GetRunTimeLevelData(level);

            if (_currentLevelData == null)
            {
                Debug.LogError($"{nameof(GameHandler)}���d��Ƭ�null!");
                return;
            }
            CurrentLevel = level;
            SetupLevel(_currentLevelData, Vector3.zero);
        }

        /// <summary>
        /// �P�_���w���ʤ�V <paramref name="inputDirection"/> �O�_���X�k���ʡC
        /// </summary>
        /// <param name="inputDirection">���ˬd�����ʤ�V</param>
        /// <returns>�X�k�^�� true�A�_�h false</returns>
        public bool IsValidMove(InputDirection inputDirection)
        {
            return _gamePlay != null && _gamePlay.IsValidMove(inputDirection);
        }

        /// <summary>
        /// ����@���X�k���ʡG����u�ʰʵe�ç�s�޿�P�B�ơC
        /// </summary>
        /// <param name="inputDirection">���ʤ�V</param>
        public void ValidMove(InputDirection inputDirection)
        {
            var positions = _gamePlay.GetBlockState(out BlockState blockState);
            _blockView.DisplayLegalMove(inputDirection, blockState);
            _gamePlay.MoveBlock(inputDirection);

            MoveCount++;
            IsInAnimation = true;
        }

        /// <summary>
        /// ����@���D�k���ʡG����^�u�ʵe�]���ܿ��~�^�C
        /// </summary>
        /// <param name="inputDirection">���ժ����ʤ�V</param>
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
                Debug.LogError($"{nameof(GameHandler)}: _gridRender ���]�w�I");
            }
            if (_blockView == null)
            {
                Debug.LogError($"{nameof(GameHandler)}: _blockView ���]�w�I");
            }
            if (_levelDataManager == null)
            {
                Debug.LogError($"{nameof(GameHandler)}: levelDatas ���]�w�I");
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
