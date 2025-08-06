using System.Collections.Generic;
using UnityEngine;
namespace HomeWork.ObjectPool
{
    /// <summary>
    /// �q�Ϊ�����A��������~�Ӧ�MonoBehaviour���ե�
    /// </summary>
    /// <typeparam name="T">���������A�����~�Ӧ�MonoBehaviour</typeparam>
    public class ObjectPool<T> 
        where T : MonoBehaviour
    {
        private Queue<T> _pool = new Queue<T>();
        private T _prefab;
        private Transform _parent;
        private int _initialSize;

        /// <summary>
        /// ��l�ƪ����
        /// </summary>
        /// <param name="prefab">�w�s����</param>
        /// <param name="initialSize">��l�j�p</param>
        /// <param name="parent">������</param>
        public ObjectPool(T prefab, int initialSize, Transform parent)
        {
            if (prefab == null) 
            {
                Debug.LogError($"{nameof(ObjectPool<T>)}��������󬰪�!");
            }
            if (initialSize < 0)
            {
                Debug.LogWarning($"{nameof(ObjectPool<T>)} initialSize�p��0!");
            }
            _prefab = prefab;
            _initialSize = initialSize;
            _parent = parent;

            InitializePool();
        }

        /// <summary>
        /// �q�������o����
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
        /// �N�����k�٨����
        /// </summary>
        public void Return(T obj)
        {
            if (obj == null)
            {
                Debug.LogWarning($"{nameof(ObjectPool<T>)}��^�Ū���!");
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
        /// �M�Ū����
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

