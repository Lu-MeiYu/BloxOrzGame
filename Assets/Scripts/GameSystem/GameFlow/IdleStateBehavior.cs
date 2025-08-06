using HomeWork.GameCamera;
using HomeWork.GameInput;
using HomeWork.UI;
using UnityEngine;
namespace HomeWork.GameSystem
{
    public class IdleStateBehavior : StateMachineBehaviour
    {
        private Animator _animator;
        private InputModule _inputModule;
        private GameHandler _gameHandler;
        private GameUIManager _gameUIManager;
        private CameraController _cameraController;
        private bool _pendingWin;

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            _animator = animator;
            _pendingWin = false;

            bool canPressPreLevelButton = _gameHandler.CurrentLevel > 1;
            bool canPressNextLevelButton = _gameHandler.CurrentLevel < _gameHandler.MaxLevel;
            _gameUIManager.InteractablePreLevelButton(canPressPreLevelButton);
            _gameUIManager.InteractableNextLevelButton(canPressNextLevelButton);

            _gameHandler.OnValidMoveCompleted += OnRollFinished;
            _gameHandler.OnInValidMoveCompleted += OnRollFinished;
            _gameUIManager.OnNextLevelRequested += OnNextLevelButtonClick;
            _gameUIManager.OnPrevLevelRequested += OnPrevLevelButtonClick;
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            _cameraController.MoveCamera(_inputModule.GetAxisValue());

            if (!_inputModule.TryDetectSwipe(out InputDirection direction) || _gameHandler.IsInAnimation)
            {
                return;
            }

            if (_gameHandler.IsValidMove(direction))
            {
                _gameHandler.ValidMove(direction);
                _gameUIManager.UpdateStep(_gameHandler.MoveCount);
                _gameUIManager.AddItemToScrollView(direction.ToString());
            }
            else
            {
                _gameHandler.InValidMove(direction);
            }

            if (_gameHandler.IsWin)
            {
                _pendingWin = true;
            }
        }
        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            _gameHandler.OnValidMoveCompleted -= OnRollFinished;
            _gameHandler.OnInValidMoveCompleted -= OnRollFinished;
            _gameUIManager.OnNextLevelRequested -= OnNextLevelButtonClick;
            _gameUIManager.OnPrevLevelRequested -= OnPrevLevelButtonClick;
        }
        public void Inject(InputModule inputModule, CameraController cameraController, GameUIManager gameUIManager, GameHandler gameHandler)
        {
            _inputModule = inputModule;
            _cameraController = cameraController;
            _gameUIManager = gameUIManager;
            _gameHandler = gameHandler;

            CheckDependence();
        }
        private void CheckDependence()
        {
            if (_inputModule == null) 
            {
                Debug.LogError($"{nameof(IdleStateBehavior)}inputModule不可為null!請檢查注入物件");
            }
            if (_gameHandler == null)
            {
                Debug.LogError($"{nameof(IdleStateBehavior)}gameHandler不可為null!請檢查注入物件");
            }
            if (_gameUIManager == null)
            {
                Debug.LogError($"{nameof(IdleStateBehavior)}gameUIManager不可為null!請檢查注入物件");
            }
            if (_cameraController == null)
            {
                Debug.LogError($"{nameof(IdleStateBehavior)}cameraController不可為null!請檢查注入物件");
            }
        }
        private void OnNextLevelButtonClick()
        {
            ChangeLevel(+1);
        }
        private void OnPrevLevelButtonClick()
        {
             ChangeLevel(-1);
        }
        private void ChangeLevel(int delta)
        {
            if (_gameHandler.IsInAnimation || _animator.IsInTransition(0)) 
            {
                return;
            }
             int nextLevel = _gameHandler.CurrentLevel + delta;
            _animator.SetInteger("nextLoadLevel", nextLevel);
            _animator.SetTrigger("loadLevel");
        }

        private void OnRollFinished()
        {
            if (_pendingWin)
            {
                _animator.SetTrigger("levelClear");
                _pendingWin = false;
            }
        }
    }
}
