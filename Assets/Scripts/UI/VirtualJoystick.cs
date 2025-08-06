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
                Debug.LogError($"{name} joystickBackground��joystickHandle�S���]�m�A���˹�!");
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

            //�ˬd�g�u�i�_�P�ӥ����ۥ�
            if (!RectTransformUtility.ScreenPointToLocalPointInRectangle(joystickBackground, eventData.position,
                eventData.pressEventCamera, out localPoint))
            {
                return;
            }
            localPoint -= _backgroundSize / 2;

            //�p��point�۹��I�������I�۹�зǤƦ�m
            Vector2 normalized = new Vector2(
                localPoint.x / (_backgroundSize.x * 0.5f),
                localPoint.y / (_backgroundSize.y * 0.5f)
            );

            GetAxisVaule = normalized.magnitude > 1f
                ? normalized.normalized
                : normalized;

            //�]�m�n�쪺��m(�Z��Anchor�h��)
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

