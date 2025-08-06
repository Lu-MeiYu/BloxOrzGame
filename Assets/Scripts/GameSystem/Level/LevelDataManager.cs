using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HomeWork.GameSystem
{
    [CreateAssetMenu(fileName = "LevelDatas", menuName = "Game/LevelDataManager")]
    public class LevelDataManager : ScriptableObject
    {
        [SerializeField] private List<LevelData> _levels;

        public int MaxCount => _levels.Count;
        public LevelData GetRunTimeLevelData(int level) 
        {
            if (level < 1 || level > _levels.Count)
            {
                Debug.LogError($"{nameof(LevelDataManager)}無效關卡編號：{level}");
                return default;
            }

            LevelData levelData = Instantiate(_levels[level-1]);
            return levelData;
        }

        public void AddLevelData(LevelData data) 
        {
            _levels.Add(data);
        }
    }
}
