using System.Collections;
using System;
using UnityEngine;
using UnityEngine.UI;
using HomeWork.TweenService;
using TMPro;
namespace HomeWork.UI
{
    public class GameUIManager : MonoBehaviour
    {
        public event Action OnNextLevelRequested;
        public event Action OnPrevLevelRequested;
        public event Action OnReplayButtonRequested;
        public event Action OnMenuExitRequested;
        public event Action OnFinishExitRequested;
        public event Action OnContinueRequested;
        public event Action OnMenuRequested;

        [SerializeField] private float _loadLevelFadeTime;
        [SerializeField] private Button _nextLevelButton;
        [SerializeField] private Button _preLevelButton;
        [SerializeField] private Button _replayButton;
        [SerializeField] private Button _menuExitButton;
        [SerializeField] private Button _finishExitButton;
        [SerializeField] private Button _continueButton;
        [SerializeField] private Button _menuButton;
        [SerializeField] private Image _changeLevelPanel;
        [SerializeField] private Image _blockPanel;
        [SerializeField] private Image _menuPanel;
        [SerializeField] private Image _finishPanel;
        [SerializeField] private Canvas _sceneCanvas;
        [SerializeField] private TMP_Text _stepText;
        [SerializeField] private LoopScrollView _loopScrollView;
        public void Initialize()
        {
            CheckSetting();

            _nextLevelButton?.onClick.AddListener(() => OnNextLevelRequested?.Invoke());

            _preLevelButton?.onClick.AddListener(() => OnPrevLevelRequested?.Invoke());

            _replayButton?.onClick.AddListener(() => OnReplayButtonRequested?.Invoke());

            _menuExitButton?.onClick.AddListener(() => OnMenuExitRequested?.Invoke());

            _finishExitButton?.onClick?.AddListener(() => OnFinishExitRequested?.Invoke());

            _continueButton?.onClick.AddListener(() => OnContinueRequested?.Invoke());

            _menuButton?.onClick.AddListener(() => OnMenuRequested?.Invoke());

            OnMenuRequested += () => ActiveMenu(true);

            OnContinueRequested += () => ActiveMenu(false);

            _loopScrollView.Initialize();

            ActiveBlockPanel(false);
        }
        public void ActiveMenu(bool active)
        {
            ActiveBlockPanel(active);
            _menuPanel?.gameObject.SetActive(active);
            _menuPanel?.gameObject.transform.SetAsLastSibling();
        }
        public void ActiveFinishPanel(bool active)
        {
            ActiveBlockPanel(active);
            _finishPanel?.gameObject.SetActive(active);
            _finishPanel?.gameObject.transform.SetAsLastSibling();
        }
        public void InteractableNextLevelButton(bool interactable)
        {
            if (_nextLevelButton != null)
            {
                _nextLevelButton.interactable = interactable;
            }
        }
        public void InteractablePreLevelButton(bool interactable)
        {
            if (_preLevelButton != null)
            {
                _preLevelButton.interactable = interactable;
            }
        }
        public void AddItemToScrollView(string Text)
        {
            _loopScrollView?.AddData(Text);
        }

        public void ClearScrollViewItem()
        {
            _loopScrollView?.ClearData();
        }

        public void FadeInLoadingPanel(Action onFinishAction)
        {
            StartCoroutine(FadeInPanelEnumerator(onFinishAction));
        }
        public void FadeOutLoadingPanel(Action onFinishAction)
        {
            StartCoroutine(FadeOutPanelEnumerator(onFinishAction));
        }
        public void UpdateStep(int stepCount)
        {
            if (_stepText != null)
            {
                _stepText.text = stepCount.ToString();
            }
        }

        public void OpenSceneUI(bool open)
        {
            _sceneCanvas.gameObject.SetActive(open);
        }
        private void ActiveLevelPanel(bool active)
        {
            _changeLevelPanel?.gameObject.SetActive(active);
            _changeLevelPanel?.gameObject.transform.SetAsLastSibling();
        }
        private void ActiveBlockPanel(bool active)
        {
            _blockPanel?.gameObject.SetActive(active);
            _blockPanel?.transform.SetAsLastSibling();
        }

        private void OnDestroy()
        {
            _nextLevelButton?.onClick.RemoveAllListeners();
            _preLevelButton?.onClick.RemoveAllListeners();
            _replayButton?.onClick.RemoveAllListeners();
            _finishExitButton?.onClick.RemoveAllListeners();
            _menuExitButton?.onClick.RemoveAllListeners();
            _continueButton?.onClick.RemoveAllListeners();
            _menuButton?.onClick.RemoveAllListeners();
        }

        private IEnumerator FadeInPanelEnumerator(Action onFinishAction)
        {
            if (_changeLevelPanel != null)
            {
                ActiveLevelPanel(true);
                _changeLevelPanel.color = Color.black;
                Color transparent = new Color(0, 0, 0, 0);
                yield return DoTweenService.FadeColor(_changeLevelPanel, transparent, Color.black, _loadLevelFadeTime);
            }
            onFinishAction?.Invoke();
        }

        private IEnumerator FadeOutPanelEnumerator(Action onFinishAction)
        {
            if (_changeLevelPanel != null)
            {
                Color transparent = new Color(0, 0, 0, 0);
                _changeLevelPanel.color = transparent;
                yield return DoTweenService.FadeColor(_changeLevelPanel, Color.black, transparent, _loadLevelFadeTime);
                ActiveLevelPanel(false);
            }
            onFinishAction?.Invoke();
        }
        private void CheckSetting()
        {
            if (_nextLevelButton == null) Debug.LogError($"{name} nextLevelButton ���i��null�I");
            if (_preLevelButton == null) Debug.LogError($"{name} preLevelButton ���i��null�I");
            if (_replayButton == null) Debug.LogError($"{name} replayButton ���i��null�I");
            if (_menuExitButton == null) Debug.LogError($"{name} menuExitButton ���i��null�I");
            if (_finishExitButton == null) Debug.LogError($"{name} finishExitButton ���i��null�I");
            if (_continueButton == null) Debug.LogError($"{name} continueButton ���i��null�I");
            if (_menuButton == null) Debug.LogError($"{name} menuButton ���i��null�I");
            if (_changeLevelPanel == null) Debug.LogError($"{name} changeLevelPanel ���i��null�I");
            if (_blockPanel == null) Debug.LogError($"{name} blockPanel ���i��null�I");
            if (_menuPanel == null) Debug.LogError($"{name} menuPanel ���i��null�I");
            if (_finishPanel == null) Debug.LogError($"{name} finishPanel ���i��null�I");
            if (_sceneCanvas == null) Debug.LogError($"{name} sceneCanvas ���i��null�I");
            if (_stepText == null) Debug.LogError($"{name} stepText ���i��null�I");
            if (_loopScrollView == null) Debug.LogError($"{name} loopScrollView ���i��null�I");
            if (_loadLevelFadeTime < 0f)
            {
                Debug.LogWarning($"{name} loadLevelFadeTime �����p��0�I");
                _loadLevelFadeTime = 0f;
            }
        }
    }
}
