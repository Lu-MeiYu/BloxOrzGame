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
        //��Loading�ɶ��W�L�]�m��LoadingDuration�A�N�|�b�[��������g�LbufferTime�ɶ��~����Loading�e��
        [SerializeField] private float _bufferTime;
        public static SceneManagerAsync Instance { get; private set; }

        /// <summary>
        /// ���J�s�����A�P�����Ū���e���C
        /// </summary>
        /// <param name="sceneName">�n���J�������W��</param>
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

            //�p�G���Ū���һݮɶ� > �]�wŪ���ɶ��A�bŪ��������g�L_bufferTime��~�|����LoadingUI�B�I�s����LoadingUI�ƥ�
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
            Debug.LogError($"{nameof(SceneManagerAsync)}�L�k�b�������󤤧���~��SceneInitializer����A���ˬd��������");
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
                Debug.LogWarning($"�����SceneManagerAsync�b�����W�A�N�۰ʾP��:{gameObject.name}");
                Destroy(this);
            }
        }
    }
}
