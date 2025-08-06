using UnityEngine;
using HomeWork.SceneRoot;
namespace HomeWork.GameInput {
    public class InputModule
    {
        private float _swipeThreshold = 100; //(�w�]��)
        private  ISwipeDetect _swipeDetector;
        private  IAxisDetect _axisDetector;
        private readonly CameraRelativeInputMapper _inputMapper;

        /// <summary>
        /// �P�w���ưʿ�J���̤p�Z���]�ù��y�С^
        /// �p�󦹶Z���N���Q�����ư�
        /// </summary>
        public float SwipeThreshold
        {
            get => _swipeThreshold;
            set
            {
                if (value < 0f)
                {
                    Debug.LogWarning($"{nameof(StartSceneHandler)}SwipeThreshold �������D�t�ȡA�۰ʳ]��0");
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
        /// ���o�ثe�b�V��J�ȡ]�Ҧp�����n�����L WSAD�^�C
        /// </summary>
        public Vector2 GetAxisValue()
        {
           return _axisDetector.GetAxisVaule;
        }


        /// <summary>
        /// ���հ����@���ưʿ�J�C�Y�ưʦV�q�W�L�H�ȡA�ഫ���@�ɤ�V��^�� <see cref="InputDirection"/>�C
        /// </summary>
        /// <returns>�Y�����즳�ķưʡA�^�� true �æb out �ѼƦ^���V�F�_�h�^�� false�C</returns>
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
                Debug.LogError($"{nameof(StartSceneHandler)}swipeDetector���i��null!");
            }
            if (_inputMapper == null)
            {
                Debug.LogError($"{nameof(StartSceneHandler)}inputMapper���i��null!");
            }
            if (_axisDetector == null)
            {
                Debug.LogError($"{nameof(StartSceneHandler)}axisDetector���i��null!");
            }
        }
    }
}
