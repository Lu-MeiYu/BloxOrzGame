using UnityEngine;
using HomeWork.SceneRoot;
namespace HomeWork.GameInput {
    public class InputModule
    {
        private float _swipeThreshold = 100; //(預設值)
        private  ISwipeDetect _swipeDetector;
        private  IAxisDetect _axisDetector;
        private readonly CameraRelativeInputMapper _inputMapper;

        /// <summary>
        /// 判定為滑動輸入的最小距離（螢幕座標）
        /// 小於此距離將不被視為滑動
        /// </summary>
        public float SwipeThreshold
        {
            get => _swipeThreshold;
            set
            {
                if (value < 0f)
                {
                    Debug.LogWarning($"{nameof(StartSceneHandler)}SwipeThreshold 必須為非負值，自動設為0");
                    _swipeThreshold = 0;
                    return;
                }
                _swipeThreshold = value;
            }
        }

        public InputModule(ISwipeDetect swipeDetector, CameraRelativeInputMapper inputMapper, IAxisDetect axisDetector)
        {
            _swipeDetector = swipeDetector;
            _inputMapper = inputMapper;
            _axisDetector = axisDetector;

            CheckDependence();
        }
        /// <summary>
        /// 取得目前軸向輸入值（例如虛擬搖桿或鍵盤 WSAD）。
        /// </summary>
        public Vector2 GetAxisValue()
        {
           return _axisDetector.GetAxisVaule;
        }


        /// <summary>
        /// 嘗試偵測一次滑動輸入。若滑動向量超過閾值，轉換為世界方向後回傳 <see cref="InputDirection"/>。
        /// </summary>
        /// <returns>若偵測到有效滑動，回傳 true 並在 out 參數回填方向；否則回傳 false。</returns>
        public bool TryDetectSwipe(out InputDirection direction)
        {
            if ((_swipeDetector.DetectSwipe(out Vector2 swipeDelta)) && (swipeDelta.magnitude >= _swipeThreshold))
            {
                Vector2 worldDelta = _inputMapper.RelativeDirection(swipeDelta);
                direction = DetermineDirection(worldDelta);
                return true;
            }

            direction = default;
            return false;
        }
        private InputDirection DetermineDirection(Vector2 value)
        {
            if (Mathf.Abs(value.x) > Mathf.Abs(value.y))
            {
                return value.x > 0f ? InputDirection.Right : InputDirection.Left;
            }
            else
            {
                return value.y > 0f ? InputDirection.Up : InputDirection.Down;
            }
        }
        private void CheckDependence()
        {
            if (_swipeDetector == null)
            {
                Debug.LogError($"{nameof(StartSceneHandler)}swipeDetector不可為null!");
            }
            if (_inputMapper == null)
            {
                Debug.LogError($"{nameof(StartSceneHandler)}inputMapper不可為null!");
            }
            if (_axisDetector == null)
            {
                Debug.LogError($"{nameof(StartSceneHandler)}axisDetector不可為null!");
            }
        }
    }
}
