using System.Collections.Generic;
using UnityEngine;
namespace HomeWork.ObjectPool
{
    /// <summary>
    /// 通用物件池，支持任何繼承自MonoBehaviour的組件
    /// </summary>
    /// <typeparam name="T">物件類型，必須繼承自MonoBehaviour</typeparam>
    public class ObjectPool<T> 
        where T : MonoBehaviour
    {
        private Queue<T> _pool = new Queue<T>();
        private T _prefab;
        private Transform _parent;
        private int _initialSize;

        /// <summary>
        /// 初始化物件池
        /// </summary>
        /// <param name="prefab">預製物件</param>
        /// <param name="initialSize">初始大小</param>
        /// <param name="parent">父物件</param>
        public ObjectPool(T prefab, int initialSize, Transform parent)
        {
            if (prefab == null) 
            {
                Debug.LogError($"{nameof(ObjectPool<T>)}物件池物件為空!");
            }
            if (initialSize < 0)
            {
                Debug.LogWarning($"{nameof(ObjectPool<T>)} initialSize小於0!");
            }
            _prefab = prefab;
            _initialSize = initialSize;
            _parent = parent;

            InitializePool();
        }

        /// <summary>
        /// 從池中取得物件
        /// </summary>
        public T Get()
        {
            T obj;

            if (_pool.Count > 0)
            {
                obj = _pool.Dequeue();
            }
            else
            {
                obj = CreateObject();
            }
            if (obj is IPoolable poolable)
            {
                poolable.OnPoolGet();
            }
            return obj;
        }

        /// <summary>
        /// 將物件歸還到池中
        /// </summary>
        public void Return(T obj)
        {
            if (obj == null)
            {
                Debug.LogWarning($"{nameof(ObjectPool<T>)}返回空物件!");
                return;
            }
            if (obj is IPoolable poolable)
            {
                poolable.OnPoolReturn();
            }
            if (_parent != null)
            {
                obj.transform.SetParent(_parent);
            }
            obj.transform.localPosition = Vector3.zero;
            obj.transform.localRotation = Quaternion.identity;
            _pool.Enqueue(obj);
        }

        /// <summary>
        /// 清空物件池
        /// </summary>
        public void Clear()
        {
            while (_pool.Count > 0)
            {
                T obj = _pool.Dequeue();
                if (obj != null)
                {
                    UnityEngine.Object.Destroy(obj.gameObject);
                }
            }
        }
        private void InitializePool()
        {
            for (int i = 0; i < _initialSize; i++)
            {
                T obj = CreateObject();
                _pool.Enqueue(obj);
            }
        }
        private T CreateObject()
        {
            T obj = UnityEngine.Object.Instantiate(_prefab, _parent);

            if (obj is IPoolable poolable)
            {
                poolable.OnPoolCreate();
            }
            return obj;
        }
    }
}

