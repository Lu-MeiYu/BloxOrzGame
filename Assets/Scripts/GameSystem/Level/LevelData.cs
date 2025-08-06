using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace HomeWork.GameSystem
{
    public class LevelData : ScriptableObject
    {
        [Header("起點／終點")]
        public Vector2 StartPoint;
        public Vector2 EndPoint;

        [Header("關卡格子座標")]
        public List<Vector2> Tiles = new List<Vector2>();
    }
}
