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
                Debug.LogError($"{nameof(StartSceneHandler)}StartUIManager不可為null!");
            }
            _startUIManager.OpenSceneUI(true);
            _startUIManager.Initialize();
            _startUIManager.OnStartRequested += OnStartRequestedHandler;

            _sceneManagerAsync = SceneManagerAsync.Instance;
            if (_sceneManagerAsync == null)
            {
                Debug.LogError($"{nameof(StartSceneHandler)}SceneManagerAsync為null!，請確保場上物件有一個SceneManagerAsync功能");
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
