using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using HomeWork.TweenService;
namespace HomeWork.LoadScene
{
    public class SceneManagerAsync : MonoBehaviour
    {
        public event Action CloseLoadingUIEvent;
        [SerializeField] private Image _filledImage;
        [SerializeField] private GameObject _loadingPanel;
        [SerializeField] private float _loadingDuration;
        private bool _canDisplayScene;
        //當Loading時間超過設置的LoadingDuration，將會在加載完畢後經過bufferTime時間才關閉Loading畫面
        [SerializeField] private float _bufferTime;
        public static SceneManagerAsync Instance { get; private set; }

        /// <summary>
        /// 載入新場景，同時顯示讀取畫面。
        /// </summary>
        /// <param name="sceneName">要載入的場景名稱</param>
        public void LoadScene(string sceneName)
        {
            StartCoroutine(LoadSceneAsync(sceneName));
        }

        private IEnumerator LoadSceneAsync(string sceneName)
        {
            _canDisplayScene = false;
            SetLoadingPanel(true);
            float currentTime = 0;
            AsyncOperation loadOp = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
            loadOp.allowSceneActivation = true;
            _filledImage.fillAmount = 0;
            StartCoroutine(DoTweenService.FilledImage(_filledImage, 0.9f, _loadingDuration));

            while (!_canDisplayScene)
            {
                currentTime += Time.deltaTime;
                yield return null;
            }

            //如果實際讀取所需時間 > 設定讀取時間，在讀取完畢後經過_bufferTime後才會關閉LoadingUI、呼叫關閉LoadingUI事件
            float timeLeft = _loadingDuration - currentTime;

            if (timeLeft < _bufferTime)
            {
                timeLeft = _bufferTime;
            }

            yield return DoTweenService.FilledImage(_filledImage, 1, timeLeft);
            SetLoadingPanel(false);
            CloseLoadingUIEvent?.Invoke();
        }
        private void SetLoadingPanel(bool Open)
        {
            _loadingPanel.SetActive(Open);
        }
        private void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
        {
            GameObject[] sceneRootObject = scene.GetRootGameObjects();
            foreach (var item in sceneRootObject)
            {
                if (item.TryGetComponent<SceneInitializer>(out SceneInitializer sceneInitializer))
                {
                    sceneInitializer.Initialize(() => _canDisplayScene = true);
                    return;
                }
            }
            Debug.LogError($"{nameof(SceneManagerAsync)}無法在場景物件中找到繼承SceneInitializer物件，請檢查場景物件");
        }
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                SceneManager.sceneLoaded += OnSceneLoaded;
                DontDestroyOnLoad(this);
            }
            else
            {
                Debug.LogWarning($"有兩個SceneManagerAsync在場景上，將自動銷毀:{gameObject.name}");
                Destroy(this);
            }
        }
    }
}
