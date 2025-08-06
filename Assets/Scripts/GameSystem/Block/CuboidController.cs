using System.Collections;
using UnityEngine;
using System;
using HomeWork.GameInput;
namespace HomeWork.GameSystem
{

    public class CuboidController : MonoBehaviour,
        ICuboidView
    {
        public event Action OnFinishLegalAnimation;
        public event Action OnFinishIllegalAnimtion;

        private const int _allowedDigits = 5;
        private const float _rotationAngle = 90;

        [SerializeField] private float _legalrollDuration;
        [SerializeField] private float _illegalRollAngle;
        public void Initialize(Vector3 startPointWorldPosition)
        {
            if (_legalrollDuration <= 0) 
            {
                Debug.LogWarning($"{nameof(CuboidController)}legalrollDuration不應小於0!，自動設為1");
                _legalrollDuration = 1;
            }
            if (_illegalRollAngle <= 0)
            {
                Debug.LogWarning($"{nameof(CuboidController)}非法移動動畫旋轉小於0!");
            }
            float centerHight = transform.localScale.y / 2;
            transform.rotation = Quaternion.identity;
            transform.position = startPointWorldPosition + new Vector3(0,centerHight);
        }

        public void DisplayLegalMove(InputDirection direction, BlockState blockState)
        {
            StartCoroutine(RollToDirection(direction, blockState, _rotationAngle));
        }

        public void DisplayIllegalMove(InputDirection direction, BlockState blockState)
        {
            StartCoroutine(TurnBackRoll(direction, blockState, _illegalRollAngle));
        }

        //根據當前狀態中心點與旋轉點的距離差絕對值與旋轉方向計算出實際的旋轉點位置
        private Vector3 ComputePivot(InputDirection dir, BlockState state)
        {
            Vector3 directionVector = GetDirectionVector(dir);
            Vector2 offset = GetPivotOffset(dir, state);
            return transform.position
                 + directionVector * offset.x
                 + Vector3.down * offset.y;
        }

        private IEnumerator RotateRoutine(Vector3 pivot, Vector3 axis, float angle, float duration)
        {
            float elapsed = 0f;
            while (elapsed < duration)
            {
                float delta = Time.deltaTime;
                elapsed += delta;
                RotateBlock(pivot, axis, angle * (delta / duration));
                yield return null;
            }
            //把多轉的轉回去，並且修正位置誤差
            if (!Mathf.Approximately(elapsed, duration))
            {
                float remain = duration - elapsed;
                RotateBlock(pivot, axis, angle * (remain / duration));
                EliminatePositionErrors(_allowedDigits);
            }
        }
        private IEnumerator RollToDirection(InputDirection dir, BlockState state, float angle)
        {
            Vector3 axis = GetRotateAxis(dir);
            Vector3 pivot = ComputePivot(dir, state);

            yield return RotateRoutine(pivot, axis, angle, _legalrollDuration);

            OnFinishLegalAnimation?.Invoke();
        }

        private IEnumerator TurnBackRoll(InputDirection dir, BlockState state, float angle)
        {
            Vector3 axis = GetRotateAxis(dir);
            Vector3 pivot = ComputePivot(dir, state);
            float halfTime = _legalrollDuration * 0.5f;

            yield return RotateRoutine(pivot, axis, angle, halfTime);
            yield return RotateRoutine(pivot, axis, -angle, halfTime);

            OnFinishIllegalAnimtion?.Invoke();
        }
        //以pivot為圓心計算transform旋轉後的位置和旋轉值
        private void RotateBlock(Vector3 pivot, Vector3 axis, float angle)
        {
            Vector3 positionOffset = transform.position - pivot;
            Vector3 newPosition = pivot + Quaternion.AngleAxis(angle, axis) * positionOffset;
            transform.position = newPosition;
            transform.rotation = Quaternion.AngleAxis(angle, axis) * transform.rotation;
        }

        //修正位置誤差
        private void EliminatePositionErrors(int digits)
        {
            float newPositionX = MathF.Round(transform.position.x, digits);
            float newPositionY = MathF.Round(transform.position.y, digits);
            float newPositionZ = MathF.Round(transform.position.z, digits);
            transform.position = new Vector3(newPositionX, newPositionY, newPositionZ);
        }
        private Vector3 GetRotateAxis(InputDirection direction)
        {
            switch (direction)
            {
                case InputDirection.Left:
                    return Vector3.forward;
                case InputDirection.Up:
                    return Vector3.right;
                case InputDirection.Right:
                    return Vector3.back;
                case InputDirection.Down:
                    return Vector3.left;
                default:
                    return Vector3.zero;
            }
        }

        private Vector3 GetDirectionVector(InputDirection direction)
        {
            switch (direction)
            {
                case InputDirection.Left:
                    return Vector3.left;
                case InputDirection.Up:
                    return Vector3.forward;
                case InputDirection.Right:
                    return Vector3.right;
                case InputDirection.Down:
                    return Vector3.back;
                default:
                    return Vector3.zero;
            }
        }
        //取得物件中心點和旋轉點的距離絕對值
        private Vector2 GetPivotOffset(InputDirection direction, BlockState blockState)
        {
            Vector2 pivotOffset = Vector2.zero;
            Vector2 center = transform.localScale / 2;

            switch (blockState)
            {
                case BlockState.LieHorizontal:
                    if (direction == InputDirection.Left || direction == InputDirection.Right)
                    {
                        pivotOffset = new Vector2(center.y, center.x);
                    }
                    else
                    {
                        pivotOffset = Vector2.one * center.x;
                    }
                    break;
                case BlockState.Stand:
                    pivotOffset = center;
                    break;
                case BlockState.LieVerticle:
                    if (direction == InputDirection.Up || direction == InputDirection.Down)
                    {
                        pivotOffset = new Vector2(center.y, center.x);
                    }
                    else
                    {
                        pivotOffset = Vector2.one * center.x;
                    }
                    break;
            }
            return pivotOffset;
        }
    }
}
