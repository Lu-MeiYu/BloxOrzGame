using System.Collections;
using UnityEngine;
using HomeWork.LoadScene;
using HomeWork.GameCamera;
using HomeWork.GameInput;
using HomeWork.GameSystem;
using HomeWork.UI;

namespace HomeWork.SceneRoot
{
    /// <summary>
    /// �t�d�����޿誺�ҰʡB�ƥ�q�\�C
    /// </summary>
    public class GameSceneHandler : SceneInitializer
    {
        [SerializeField] private GameUIManager _gameUIManager;
        [SerializeField] private VirtualJoystick _virtualJoystick;
        [SerializeField] private CameraController _cameraController;
        [SerializeField] private GridRenderer _gridRenderer;
        [SerializeField] private GameObject _blockControllerPrefab;
        [SerializeField] private LevelDataManager _levelDataManager;

        [SerializeField] private int DefaultItemScrollItemCount = 1000;
        [SerializeField] private int DefaultScrollYieldInterval = 30;
        private GameHandler _gameHandler;
        private Animator _gameFlowAnimator;
        private InputModule _inputModule;
        private SceneManagerAsync _sceneManagerAsync;

        protected override IEnumerator OnSceneLoad()
        {
            _sceneManagerAsync = SceneManagerAsync.Instance;
            ValidateDependencies();
            InitializeModules();
            InjectStateBehaviours();
            SubscribeEvents();

            yield return PopulateScrollView(DefaultItemScrollItemCount, DefaultScrollYieldInterval);

            _gameFlowAnimator.enabled = true;
        }

        private void ValidateDependencies()
        {
            if (_gridRenderer == null)
            {
                Debug.LogError($"{name}gridRenderer���i��null!���ˬd���");
            }
            if (_blockControllerPrefab == null)
            {
                Debug.LogError($"{name}blockControllerPrefab���i��null!���ˬd���");
            }
            if (_levelDataManager == null)
            {
                Debug.LogError($"{name}levelDatas���i��null!���ˬd���");
            }
            if (_gameUIManager == null)
            {
                Debug.LogError($"{name}gameUIManager!���ˬd���");
            }
            if (_virtualJoystick == null)
            {
                Debug.LogError($"{name}virtualJoystick!���ˬd���");
            }
            if (_cameraController == null)
            {
                Debug.LogError($"{name}cameraController!���ˬd���");
            }
            if (Camera.main == null)
            {
                Debug.LogError($"{nameof(GameSceneHandler)}�䤣��MainCamera");
            }
            if (_sceneManagerAsync == null)
            {
                Debug.LogError($"{nameof(GameSceneHandler)}�䤣��sceneManagerAsync�A�нT�{���W�ܤ֦��@��sceneManagerAsync");
            }
        }

        private void InitializeModules()
        {

            IBlockLogic blockLogic = new CuboidBlock();
            IGameLogic gameLogic = new GameLogic(blockLogic);

            GameObject blockGameObject = Instantiate(_blockControllerPrefab);
            if (!blockGameObject.TryGetComponent<ICuboidView>(out ICuboidView iCuboidView))
            {
                Debug.LogError($"�b{_blockControllerPrefab}�䤣��ICuboidView�\��!�нT�{");
            }

            ICuboidView cuboidView = iCuboidView;
            IGridRender gridRender = _gridRenderer;
            gridRender.Initialize();
            _gameHandler = new GameHandler(gridRender, cuboidView, _levelDataManager, gameLogic);
            _gameHandler.SetLevel(1);

            CameraRelativeInputMapper cameraRelativeInputMapper = new CameraRelativeInputMapper(Camera.main);
            ISwipeDetect swipeDetector = new AndroidInputDetecter();
            IAxisDetect axisDetector = _virtualJoystick;
            _inputModule = new InputModule(swipeDetector, cameraRelativeInputMapper, axisDetector);

            _cameraController.InitializeSetting();

            _gameUIManager.Initialize();

            _gameFlowAnimator = GetComponent<Animator>();
        }

        private void InjectStateBehaviours()
        {
            foreach (var idle in _gameFlowAnimator.GetBehaviours<IdleStateBehavior>())
            {
                idle.Inject(_inputModule, _cameraController, _gameUIManager, _gameHandler);
            }

            foreach (var loader in _gameFlowAnimator.GetBehaviours<LoadLevelBehavior>())
            {
                loader.Inject(_gameHandler, _gameUIManager);
            }

            foreach (var clearer in _gameFlowAnimator.GetBehaviours<LevelClearBehavior>())
            {
                clearer.Inject(_gameHandler, _gameUIManager);
            }
        }
        private IEnumerator PopulateScrollView(int totalItems, int yieldInterval)
        {
            for (int i = 0; i < totalItems; i++)
            {
                _gameUIManager.AddItemToScrollView(i.ToString());
                if (i % yieldInterval == 0)
                {
                    yield return null;
                }
            }
        }
        private void SubscribeEvents()
        {
            _gameUIManager.OnMenuRequested += HandleMenuRequested;
            _gameUIManager.OnContinueRequested += HandleContinueRequested;
            _gameUIManager.OnMenuExitRequested += HandleMenuExitRequested;
            _gameUIManager.OnFinishExitRequested += HandleFinishExitRequested;
            _sceneManagerAsync.CloseLoadingUIEvent += HandleCloseLoadingUIEvent;
        }

        private void HandleMenuRequested() => _gameUIManager.ActiveMenu(true);
        private void HandleContinueRequested() => _gameUIManager.ActiveMenu(false);
        private void HandleMenuExitRequested() => ApplicationManager.Instance.ExitGame();
        private void HandleFinishExitRequested() => ApplicationManager.Instance.ExitGame();
        private void HandleCloseLoadingUIEvent() => _gameUIManager.OpenSceneUI(true);


        private void OnDestroy()
        {
            _gameUIManager.OnMenuRequested -= HandleMenuRequested;
            _gameUIManager.OnContinueRequested -= HandleContinueRequested;
            _gameUIManager.OnMenuExitRequested -= HandleMenuExitRequested;
            _gameUIManager.OnFinishExitRequested -= HandleFinishExitRequested;
            _sceneManagerAsync.CloseLoadingUIEvent -= HandleCloseLoadingUIEvent;
        }
    }
}