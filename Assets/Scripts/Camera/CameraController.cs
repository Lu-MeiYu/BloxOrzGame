using UnityEngine;
namespace HomeWork.GameCamera
{
    /// <summary>
    /// 控制攝影機的高度、繞著Center旋轉並看向Center
    /// </summary>
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private Vector3 Center;
        [SerializeField] private float _radius;
        [SerializeField] private float _initialHeight;
        [SerializeField] private float _minHeight;
        [SerializeField] private float _maxHeight;
        [SerializeField] private float _xSensitivity = 120f;
        [SerializeField] private float _ySensitivity = 45f;

        private float _currentAngle;
        private float _currentHeight;

        public void InitializeSetting()
        {
            CheckSetting();
            _currentAngle = 0f;
            _currentHeight = Mathf.Clamp(_initialHeight, _minHeight, _maxHeight);
            UpdateCameraTransform();
        }

        /// <summary>
        /// 設定可調整的最小／最大高度範圍。
        /// </summary>
        public void SetHeightLimits(float min, float max)
        {
            _minHeight = min;
            _maxHeight = max;
            _currentHeight = Mathf.Clamp(_currentHeight, _minHeight, _maxHeight);
        }

        /// <summary>
        /// 設定水平與垂直靈敏度。
        /// </summary>
        public void SetSensitivity(float xAxisSensitivity, float yAxisSensitivity)
        {
            _xSensitivity = xAxisSensitivity;
            _ySensitivity = yAxisSensitivity;
        }

        /// <summary>
        /// 根據輸入向量調整相機繞 Center 水平旋轉與高度。
        /// </summary>
        public void MoveCamera(Vector2 input)
        {
            _currentAngle += input.x * _xSensitivity * Time.deltaTime;
            _currentHeight = Mathf.Clamp(_currentHeight + input.y * _ySensitivity * Time.deltaTime,
                                        _minHeight, _maxHeight);

            UpdateCameraTransform();
        }

        private void UpdateCameraTransform()
        {
            Vector3 offset = new Vector3(0f, _currentHeight, -_radius);
            Quaternion rotation = Quaternion.Euler(0f, -_currentAngle, 0f);
            Vector3 worldPos = rotation * offset + Center;

            _camera.transform.position = worldPos;
            _camera.transform.LookAt(Center);
        }

        private void CheckSetting()
        {
            if (_camera == null)
            {
                Debug.LogWarning($"{name}未指定攝影機，自動套用主攝影機!");
                _camera = Camera.main;
            }
            if ((_initialHeight > _maxHeight) || (_initialHeight < _minHeight))
            {
                Debug.LogWarning($"{name}初始高度超出最大或最小值，將自動Clamp到值內");
            }
            if ((_xSensitivity < 0) || (_ySensitivity < 0))
            {
                Debug.LogWarning($"{name}水平或垂直靈敏度小於0，攝影機將不會動!");
            }
            if (_radius <= 0)
            {
                Debug.LogWarning($"{name}攝影機radius小於0!");
            }
        }
    }
}
