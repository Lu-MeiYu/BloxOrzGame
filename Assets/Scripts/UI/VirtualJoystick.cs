using HomeWork.GameInput;
using UnityEngine;
using UnityEngine.EventSystems;
namespace HomeWork.UI
{

    public class VirtualJoystick : MonoBehaviour,
        IDragHandler, IEndDragHandler, IBeginDragHandler, IAxisDetect
    {
        [SerializeField]
        private RectTransform joystickBackground;

        [SerializeField]
        private RectTransform joystickHandle;

        [SerializeField, Range(0f, 1f)]
        private float handleLimit = 1f;

        private Vector2 _backgroundSize;

        public Vector2 GetAxisVaule { get; private set; }
        public void OnBeginDrag(PointerEventData eventData)
        {
            if (joystickBackground == null || joystickHandle == null)
            {
                Debug.LogError($"{name} joystickBackground或joystickHandle沒有設置，請檢察!");
                enabled = false;
                return;
            }

            _backgroundSize = joystickBackground.sizeDelta;
            ResetHandle();

        }
        public void OnEndDrag(PointerEventData eventData)
        {
            GetAxisVaule = Vector2.zero;
            ResetHandle();
        }

        public void OnDrag(PointerEventData eventData)
        {
            Vector2 localPoint;

            //檢查射線可否與該平面相交
            if (!RectTransformUtility.ScreenPointToLocalPointInRectangle(joystickBackground, eventData.position,
                eventData.pressEventCamera, out localPoint))
            {
                return;
            }
            localPoint -= _backgroundSize / 2;

            //計算point相對於背景中間點相對標準化位置
            Vector2 normalized = new Vector2(
                localPoint.x / (_backgroundSize.x * 0.5f),
                localPoint.y / (_backgroundSize.y * 0.5f)
            );

            GetAxisVaule = normalized.magnitude > 1f
                ? normalized.normalized
                : normalized;

            //設置搖桿的位置(距離Anchor多遠)
            joystickHandle.anchoredPosition = new Vector2(
                GetAxisVaule.x * _backgroundSize.x * 0.5f * handleLimit,
                GetAxisVaule.y * _backgroundSize.y * 0.5f * handleLimit
            );
        }

        private void ResetHandle()
        {
            joystickHandle.anchoredPosition = Vector2.zero;
        }
    }
}

