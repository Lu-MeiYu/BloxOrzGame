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
                Debug.LogWarning($"{nameof(CuboidController)}legalrollDuration�����p��0!�A�۰ʳ]��1");
                _legalrollDuration = 1;
            }
            if (_illegalRollAngle <= 0)
            {
                Debug.LogWarning($"{nameof(CuboidController)}�D�k���ʰʵe����p��0!");
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

        //�ھڷ�e���A�����I�P�����I���Z���t����ȻP�����V�p��X��ڪ������I��m
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
            //��h�઺��^�h�A�åB�ץ���m�~�t
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
        //�Hpivot����߭p��transform����᪺��m�M�����
        private void RotateBlock(Vector3 pivot, Vector3 axis, float angle)
        {
            Vector3 positionOffset = transform.position - pivot;
            Vector3 newPosition = pivot + Quaternion.AngleAxis(angle, axis) * positionOffset;
            transform.position = newPosition;
            transform.rotation = Quaternion.AngleAxis(angle, axis) * transform.rotation;
        }

        //�ץ���m�~�t
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
        //���o���󤤤��I�M�����I���Z�������
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
