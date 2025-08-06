using System.Collections.Generic;
using UnityEngine;
using HomeWork.GameInput;
using System;
namespace HomeWork.GameSystem
{
    public interface IGameLogic
    {
        /// <summary>
        /// 設置關卡。
        /// </summary>
        /// <param name="levelData">關卡資料物件</param>
        public void SetGame(LevelData levelData);

        /// <summary>
        /// 檢查是否過關。
        /// </summary>
        /// <returns>若已直立站在終點回傳 true，否則 false</returns>
        public bool IsWin();

        /// <summary>
        /// 判斷向指定方向移動後，所有下一步格子是否都是合法的。
        /// </summary>
        /// <param name="direction">欲檢查的移動方向</param>
        /// <returns>合法回傳 true，否則 false</returns>
        public bool IsValidMove(InputDirection direction);

        /// <summary>
        /// 執行一次移動動作
        /// </summary>
        /// <param name="direction">移動方向</param>
        public void MoveBlock(InputDirection inputDirection);

        /// <summary>
        /// 取得當前方塊狀態與佔用格子座標。
        /// </summary>
        /// <param name="blockState">輸出：當前方塊狀態</param>
        /// <returns>方塊佔用的所有格子座標清單</returns>
        public List<Vector2> GetBlockState(out BlockState blockState);

    }
}
