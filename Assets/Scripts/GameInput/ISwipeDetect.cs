using System;
using UnityEngine;
namespace HomeWork.GameInput
{
    public interface ISwipeDetect
    {
        /// <summary>
        /// �˴��O�_�i��ư�
        /// </summary>
        /// <param name="value">��X�ưʭ�</param>
        /// <returns></returns>
        public bool DetectSwipe(out Vector2 value);
    }
}
