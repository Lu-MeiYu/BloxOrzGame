using System.Collections.Generic;
using UnityEngine;
using HomeWork.GameInput;
namespace HomeWork.GameSystem
{
    public interface IBlockLogic
    {
        /// <summary>
        /// 執行一次移動
        /// </summary>
        public void Move(InputDirection direcion);

        /// <summary>
        /// 預測向指定方向移動後，方塊會佔用的所有格子座標(由左至右，下至上排列)，及下個狀態。
        /// </summary>
        public List<Vector2> CaculateMove(InputDirection direcion,out BlockState state);

        /// <summary>
        /// 取得方塊當前所佔格子座標(由左至右，下至上排列)。
        /// </summary>

        public List<Vector2> GetCurrentPosition();

        /// <summary>
        /// 取得方塊當前狀態
        /// </summary>
        public BlockState GetBlockState();

        /// <summary>
        /// 以給定的位置與狀態，更新方塊的真實佔用格子座標。
        /// </summary>
        /// <param name="anchor">站立時為方塊位置；躺下時為左或下端格子座標。</param>
        public void SetState(Vector2 leftOrDownPoint, BlockState blockState);
    }
}
