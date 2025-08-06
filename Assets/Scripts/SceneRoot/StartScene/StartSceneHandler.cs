using System.Collections;
using UnityEngine;
using HomeWork.LoadScene;
using HomeWork.UI;
namespace HomeWork.SceneRoot
{
    public class StartSceneHandler : SceneInitializer
    {
        [SerializeField] private StartUIManager _startUIManager;
        private SceneManagerAsync _sceneManagerAsync;
        protected override IEnumerator OnSceneLoad()
        {
            if (_startUIManager == null) 
            {
                Debug.LogError($"{nameof(StartSceneHandler)}StartUIManager���i��null!");
            }
            _startUIManager.OpenSceneUI(true);
            _startUIManager.Initialize();
            _startUIManager.OnStartRequested += OnStartRequestedHandler;

            _sceneManagerAsync = SceneManagerAsync.Instance;
            if (_sceneManagerAsync == null)
            {
                Debug.LogError($"{nameof(StartSceneHandler)}SceneManagerAsync��null!�A�нT�O���W���󦳤@��SceneManagerAsync�\��");
            }
            yield break;
        }
        private void OnDestroy()
        {
            _startUIManager.OnStartRequested -= OnStartRequestedHandler;
        }
        private void OnStartRequestedHandler() => _sceneManagerAsync.LoadScene("GameScene");
    }
}
