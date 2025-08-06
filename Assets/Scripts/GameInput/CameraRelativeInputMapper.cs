using UnityEngine;
namespace HomeWork.GameInput
{
    /// <summary>
    /// �N��v������Local���Шt��V��Ƭ��@�ɮy�Шt��V
    /// </summary>
    public class CameraRelativeInputMapper
    {
        private Camera _mainCamera;

        public CameraRelativeInputMapper(Camera camera)
        {
            if (camera == null) 
            {
                Debug.LogError($"{nameof(CameraRelativeInputMapper)}��v�����i��null!,�۰ʫ���MainCamera");
                _mainCamera = Camera.main;
                return;
            }
            _mainCamera = camera;
        }

        /// <summary>
        /// �ഫ�Ȭ��@�ɮy�Шt
        /// </summary>
        /// <param name="value">��v������Local���Шt�V�q</param>
        /// <returns></returns>
        public Vector2 RelativeDirection(Vector2 value)
        {
            Vector3 fwd = _mainCamera.transform.forward;
            fwd.y = 0;
            fwd.Normalize();
            Vector3 right = _mainCamera.transform.right;
            right.y = 0;
            right.Normalize();
            Vector2 world = new Vector2(right.x, right.z) * value.x + new Vector2(fwd.x, fwd.z) * value.y;
            return world;
        }
    }
}
