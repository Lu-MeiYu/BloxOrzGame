using UnityEngine;
namespace HomeWork.GameInput
{
    /// <summary>
    /// 將攝影機視角Local坐標系方向轉化為世界座標系方向
    /// </summary>
    public class CameraRelativeInputMapper
    {
        private Camera _mainCamera;

        public CameraRelativeInputMapper(Camera camera)
        {
            if (camera == null) 
            {
                Debug.LogError($"{nameof(CameraRelativeInputMapper)}攝影機不可為null!,自動指派MainCamera");
                _mainCamera = Camera.main;
                return;
            }
            _mainCamera = camera;
        }

        /// <summary>
        /// 轉換值為世界座標系
        /// </summary>
        /// <param name="value">攝影機視角Local坐標系向量</param>
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
