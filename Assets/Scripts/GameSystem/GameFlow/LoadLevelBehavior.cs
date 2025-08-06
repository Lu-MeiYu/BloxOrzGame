using HomeWork.UI;
using UnityEngine;
namespace HomeWork.GameSystem
{
    public class LoadLevelBehavior : StateMachineBehaviour
    {
        private Animator _animator;
        private GameHandler _gameHandler;
        private GameUIManager _gameUIManager;
        private int _nextLevel;
        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            CheckDependence();
            _animator = animator;
            _nextLevel = _animator.GetInteger("nextLoadLevel");
            if ((_nextLevel < 1) || (_nextLevel > _gameHandler.MaxLevel))
            {
                Debug.LogError($"{nameof(LoadLevelBehavior)}關卡{_nextLevel}超出範圍 (1 到 {_gameHandler.MaxLevel}).");
                OnFisnishLoadLevel();
                return;
            }
            _gameUIManager.FadeInLoadingPanel(onFinishFadeIn);
        }
        public void Inject(GameHandler gameHandler, GameUIManager gameUIManager)
        {
            _gameHandler = gameHandler;
            _gameUIManager = gameUIManager;

            CheckDependence();
        }
        private void CheckDependence()
        {
            if(_gameHandler==null)
            {
                Debug.LogError($"{nameof(LoadLevelBehavior)}gameHandler不可為null!請檢查注入物件");
            }
            if (_gameUIManager == null)
            {
                Debug.LogError($"{nameof(LoadLevelBehavior)}gameUIManager不可為null!請檢查注入物件");
            }
        }
        private void onFinishFadeIn()
        {
            _gameHandler.ClearCurrentGame();
            _gameHandler.SetLevel(_nextLevel);
            _gameUIManager.UpdateStep(0);
            _gameUIManager.FadeOutLoadingPanel(OnFisnishLoadLevel);
        }

        private void OnFisnishLoadLevel() 
        {
            _animator.SetTrigger("finishLoadLevel");
        }
    }
}
