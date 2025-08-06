using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace HomeWork.GameSystem
{
    public class LevelData : ScriptableObject
    {
        [Header("�_�I�����I")]
        public Vector2 StartPoint;
        public Vector2 EndPoint;

        [Header("���d��l�y��")]
        public List<Vector2> Tiles = new List<Vector2>();
    }
}
