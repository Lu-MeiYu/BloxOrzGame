using System;
using System.Collections.Generic;
using UnityEngine;

namespace HomeWork.UI
{
    /// <summary>
    /// 緩衝資料模型，儲存最新 maxViewDataCount 筆資料，並提供可視窗口。
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
                Debug.LogWarning($"{nameof(LoopScrollViewData<T>)}maxViewDataCount數量不應低於1");
                _maxViewDataCount = 1;
            }

            _maxViewDataCount = maxViewDataCount;
            _capacity = maxViewDataCount * _capacityMultipler;
            _buffer = new List<T>(_capacity);
            _firstIndex = 0;
        }

        /// <summary>當前可視窗口內的元素數量。</summary>
        public int Count => Math.Clamp(_buffer.Count - _firstIndex, 0, _maxViewDataCount);

        /// <summary>新增一筆資料，超過容量時裁剪緩衝區。</summary>
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

        /// <summary>清空所有資料。</summary>
        public void Clear()
        {
            _buffer.Clear();
            _firstIndex = 0;
        }

        /// <summary>取得窗口內第 index 的元素。</summary>
        public T Get(int index)
        {
            if (index < 0 || index >= Count)
            {
                Debug.LogWarning($"{nameof(LoopScrollViewData<T>)}不存在第{index}筆資料!!");
                return default;
            }
            return _buffer[_firstIndex + index];
        }
    }
}