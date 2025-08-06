using HomeWork.UI;
using UnityEngine;
namespace HomeWork.GameSystem
{

    public class LevelClearBehavior : StateMachineBehaviour
    {
        private GameUIManager _gameUIManager;
        private GameHandler _gameHandler;
        private Animator _animator;

        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            _animator = animator;

            _gameUIManager.AddItemToScrollView($"Level{_gameHandler.CurrentLevel},Pass!");

            _gameUIManager.OnReplayButtonRequested += OnReplayPress;

            if (_gameHandler.CurrentLevel == _gameHandler.MaxLevel) 
            {
                _gameUIManager.ActiveFinishPanel(true);
                return;
            }

            ChangeNextLevel();
        }
       
        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            _gameUIManager.OnReplayButtonRequested -= OnReplayPress;
        }
        public void Inject(GameHandler gameHandler, GameUIManager gameUIManager)
        {
            _gameUIManager = gameUIManager;
            _gameHandler = gameHandler;

            CheckDependence();
        }
        private void CheckDependence()
        {
            if (_gameHandler == null)
            {
                Debug.LogError($"{nameof(LevelClearBehavior)}gameHandler不可為null!請檢查注入物件");
            }
            if (_gameUIManager == null)
            {
                Debug.LogError($"{nameof(LevelClearBehavior)}gameUIManager不可為null!請檢查注入物件");
            }
        }

        private void OnReplayPress() 
        {
            _gameUIManager.ActiveFinishPanel(false);
            _animator.SetInteger("nextLoadLevel", 1);
            _animator.SetTrigger("finishLevelDisplay");
        }
        private void ChangeNextLevel()
        {
            int nextLevel = _gameHandler.CurrentLevel + 1;
            _animator.SetInteger("nextLoadLevel", nextLevel);
            _animator.SetTrigger("finishLevelDisplay");
        }
    }
}
