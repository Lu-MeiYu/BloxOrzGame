using System;
using UnityEngine;
using UnityEngine.EventSystems;
namespace HomeWork.GameInput
{
    public class AndroidInputDetecter :
        ISwipeDetect
    {
        private Vector2 _startPos;
        private bool _isDraggingObject;
        public bool DetectSwipe(out Vector2 value)
        {
            if (Input.touchCount < 1)
            {
                value = default;
                return false;
            }

            var touch = Input.GetTouch(0);

            if (EventSystem.current.IsPointerOverGameObject(touch.fingerId)) 
            {
                _isDraggingObject = true;
            }

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    _startPos = touch.position;
                    _isDraggingObject = false;
                    break;
                case TouchPhase.Ended:
                    var delta = touch.position - _startPos;
                    if (!_isDraggingObject)
                    {
                        value = delta;
                        return true;
                    }
                    break;
            }
            value = default;
            return false;
        }
    }
}