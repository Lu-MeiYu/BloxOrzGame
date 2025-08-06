using System.Collections.Generic;
using UnityEngine;
namespace HomeWork.ObjectPool
{
    /// <summary>
    /// 物件池管理器單例，負責管理所有的ObjectPool
    /// </summary>
    public class ObjectPoolManager : MonoBehaviour
    {
        public static ObjectPoolManager Instance { get; private set; }

        private Dictionary<System.Type, object> _pools = new Dictionary<System.Type, object>();

        /// <summary>
        /// 創建或獲取指定類型的物件池
        /// </summary>
        /// <typeparam name="T">物件類型</typeparam>
        /// <param name="prefab">預製物件</param>
        /// <param name="initialSize">初始大小</param>
        /// <param name="customParent">自定義父物件，如果為null則自動創建</param>
        /// <returns>物件池實例</returns>
        public ObjectPool<T> GetOrCreatePool<T>(T prefab, int initialSize, Transform customParent)
            where T : MonoBehaviour
        {
            System.Type type = typeof(T);

            if (_pools.TryGetValue(type, out object existingPool))
            {
                return existingPool as ObjectPool<T>;
            }

            ObjectPool<T> newPool = new ObjectPool<T>(prefab, initialSize, customParent);
            _pools[type] = newPool;

            return newPool;
        }
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Debug.LogWarning($"有兩個ObjectPoolManager在場景上，將自動銷毀:{gameObject.name}");
                Destroy(gameObject);
            }
        }
    }
}