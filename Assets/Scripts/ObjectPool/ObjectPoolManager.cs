using System.Collections.Generic;
using UnityEngine;
namespace HomeWork.ObjectPool
{
    /// <summary>
    /// ������޲z����ҡA�t�d�޲z�Ҧ���ObjectPool
    /// </summary>
    public class ObjectPoolManager : MonoBehaviour
    {
        public static ObjectPoolManager Instance { get; private set; }

        private Dictionary<System.Type, object> _pools = new Dictionary<System.Type, object>();

        /// <summary>
        /// �Ыة�������w�����������
        /// </summary>
        /// <typeparam name="T">��������</typeparam>
        /// <param name="prefab">�w�s����</param>
        /// <param name="initialSize">��l�j�p</param>
        /// <param name="customParent">�۩w�q������A�p�G��null�h�۰ʳЫ�</param>
        /// <returns>��������</returns>
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
                Debug.LogWarning($"�����ObjectPoolManager�b�����W�A�N�۰ʾP��:{gameObject.name}");
                Destroy(gameObject);
            }
        }
    }
}