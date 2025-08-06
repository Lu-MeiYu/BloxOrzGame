using System;
using UnityEngine;
namespace HomeWork.GameInput
{
    public interface ISwipeDetect
    {
        /// <summary>
        /// 檢測是否進行滑動
        /// </summary>
        /// <param name="value">輸出滑動值</param>
        /// <returns></returns>
        public bool DetectSwipe(out Vector2 value);
    }
}
