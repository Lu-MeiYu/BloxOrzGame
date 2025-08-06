using System;
using System.Collections.Generic;
using UnityEngine;

namespace HomeWork.UI
{
    /// <summary>
    /// �w�ĸ�Ƽҫ��A�x�s�̷s maxViewDataCount ����ơA�ô��ѥi�����f�C
    /// </summary>
    public class LoopScrollViewData<T>
    {
        private readonly int _maxViewDataCount;
        private readonly int _capacity;
        private List<T> _buffer;
        private int _firstIndex;
        private const int _capacityMultipler = 2;

        public LoopScrollViewData(int maxViewDataCount)
        {
            if (maxViewDataCount < 1)
            {
                Debug.LogWarning($"{nameof(LoopScrollViewData<T>)}maxViewDataCount�ƶq�����C��1");
                _maxViewDataCount = 1;
            }

            _maxViewDataCount = maxViewDataCount;
            _capacity = maxViewDataCount * _capacityMultipler;
            _buffer = new List<T>(_capacity);
            _firstIndex = 0;
        }

        /// <summary>��e�i�����f���������ƶq�C</summary>
        public int Count => Math.Clamp(_buffer.Count - _firstIndex, 0, _maxViewDataCount);

        /// <summary>�s�W�@����ơA�W�L�e�q�ɵ��Žw�İϡC</summary>
        public void Add(T item)
        {
            _buffer.Add(item);

            if (_buffer.Count > _maxViewDataCount)
            {
                _firstIndex = _buffer.Count - _maxViewDataCount;
            }

            if (_buffer.Count > _capacity)
            {
                _buffer = _buffer.GetRange(_firstIndex, _maxViewDataCount);
                _firstIndex = 0;
            }
        }

        /// <summary>�M�ũҦ���ơC</summary>
        public void Clear()
        {
            _buffer.Clear();
            _firstIndex = 0;
        }

        /// <summary>���o���f���� index �������C</summary>
        public T Get(int index)
        {
            if (index < 0 || index >= Count)
            {
                Debug.LogWarning($"{nameof(LoopScrollViewData<T>)}���s�b��{index}�����!!");
                return default;
            }
            return _buffer[_firstIndex + index];
        }
    }
}