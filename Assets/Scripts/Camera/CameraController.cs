using UnityEngine;
namespace HomeWork.GameCamera
{
    /// <summary>
    /// ������v�������סB¶��Center����ìݦVCenter
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
        /// �]�w�i�վ㪺�̤p���̤j���׽d��C
        /// </summary>
        public void SetHeightLimits(float min, float max)
        {
            _minHeight = min;
            _maxHeight = max;
            _currentHeight = Mathf.Clamp(_currentHeight, _minHeight, _maxHeight);
        }

        /// <summary>
        /// �]�w�����P�����F�ӫסC
        /// </summary>
        public void SetSensitivity(float xAxisSensitivity, float yAxisSensitivity)
        {
            _xSensitivity = xAxisSensitivity;
            _ySensitivity = yAxisSensitivity;
        }

        /// <summary>
        /// �ھڿ�J�V�q�վ�۾�¶ Center ��������P���סC
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
                Debug.LogWarning($"{name}�����w��v���A�۰ʮM�ΥD��v��!");
                _camera = Camera.main;
            }
            if ((_initialHeight > _maxHeight) || (_initialHeight < _minHeight))
            {
                Debug.LogWarning($"{name}��l���׶W�X�̤j�γ̤p�ȡA�N�۰�Clamp��Ȥ�");
            }
            if ((_xSensitivity < 0) || (_ySensitivity < 0))
            {
                Debug.LogWarning($"{name}�����Ϋ����F�ӫפp��0�A��v���N���|��!");
            }
            if (_radius <= 0)
            {
                Debug.LogWarning($"{name}��v��radius�p��0!");
            }
        }
    }
}
