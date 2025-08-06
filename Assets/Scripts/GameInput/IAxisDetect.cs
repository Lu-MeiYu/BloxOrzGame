using UnityEngine;
namespace HomeWork.GameInput
{
    public interface IAxisDetect 
    {
        /// <summary>
        /// 根據Input回傳一個Vector2((-1~1),(-1~1))的值
        /// </summary>
        public Vector2 GetAxisVaule { get;}
    }
}
