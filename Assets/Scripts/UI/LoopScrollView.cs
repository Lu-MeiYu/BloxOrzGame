using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace HomeWork.UI
{

    /// <summary>
    /// 循環滾動列表，動態顯示 _maxItemCount 個項目。
    /// </summary>
    public class LoopScrollView : MonoBehaviour
    {
        /// <summary>封裝單一項目的引用</summary>
        private class ItemView
        {
            public GameObject GameObject { get; }
            public RectTransform Rect { get; }
            public TMP_Text TextComponent { get; }

            public ItemView(GameObject go, RectTransform rect, TMP_Text text)
            {
                GameObject = go;
                Rect = rect;
                TextComponent = text;
            }
        }

        [SerializeField] private RectTransform _content;
        [SerializeField] private TMP_Text _itemPrefab;
        [SerializeField] private ScrollRect _scrollRect;

        [SerializeField] private int _maxViewDataCount = 1000;
        [SerializeField] private float _itemPadding = 10;

        private LoopScrollViewData<string> _dataModel;
        private List<ItemView> _itemViews;
        private float _itemHeightWithPadding;
        private int _maxItemCount;
        private int _currentStartIndex;

        public void Initialize()
        {
            ValidateReferences();
            InitializeModel();
            InitializeItemViews();
            BindScrollEvent();
            Refresh();
        }

        /// <summary>加入一筆新資料。</summary>
        public void AddData(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return;
            }

            _dataModel.Add(text);
            Refresh();
            ResetScrollToBottom();
        }
        /// <summary>清除所有資料並重置列表。</summary>
        public void ClearData()
        {
            _dataModel.Clear();
            ResetScrollToTop();
            Refresh();
        }
        private void OnDestroy()
        {
            _scrollRect.onValueChanged.RemoveListener(OnScrollChanged);
        }
        private void ValidateReferences()
        {
            if (_content == null || _itemPrefab == null || _scrollRect == null)
            {
                Debug.LogError($"{nameof(LoopScrollView)}content或itemPrefab或scrollRect為null!請檢查");
            }
            if (_maxViewDataCount < 1)
            {
                Debug.LogWarning($"{nameof(LoopScrollView)}maxViewDataCount不應小於1，將自動設為1");
                _maxViewDataCount = 1;
            }
            if (_itemPadding < 0)
            {
                Debug.LogWarning($"{nameof(LoopScrollView)}itemPadding不應小於0，將自動設為0");
                _itemPadding = 0;
            }
        }

        private void InitializeModel()
        {
            _dataModel = new LoopScrollViewData<string>(_maxViewDataCount);
        }

        private void InitializeItemViews()
        {
            if (!_itemPrefab.TryGetComponent<RectTransform>(out RectTransform itemPrefabRect))
            {
                Debug.LogError($"{nameof(LoopScrollView)}無法在{_itemPrefab}上找到RectTransform，請檢察!");
                return;
            }

            _itemHeightWithPadding = itemPrefabRect.sizeDelta.y + _itemPadding;

            RectTransform scrollRectRect = _scrollRect.GetComponent<RectTransform>();
            _maxItemCount = Mathf.CeilToInt(scrollRectRect.sizeDelta.y / _itemHeightWithPadding) + 1;

            _itemViews = new List<ItemView>(_maxItemCount);
            for (int i = 0; i < _maxItemCount; i++)
            {
                var go = Instantiate(_itemPrefab.gameObject, _content);
                go.SetActive(false);
                var rect = go.GetComponent<RectTransform>();
                var text = go.GetComponent<TMP_Text>();
                _itemViews.Add(new ItemView(go, rect, text));
            }
        }

        private void BindScrollEvent()
        {
            _scrollRect.onValueChanged.AddListener(OnScrollChanged);
        }

        //當值改變的時候依照目前content距離anchored來計算出視窗中第一個item是哪個
        private void OnScrollChanged(Vector2 _)
        {
            float y = _content.anchoredPosition.y;
            int newStart = Mathf.FloorToInt(y / _itemHeightWithPadding);
            int maxStart = Math.Max(0, _dataModel.Count - _maxItemCount);
            newStart = Mathf.Clamp(newStart, 0, maxStart);

            if (newStart != _currentStartIndex)
            {
                _currentStartIndex = newStart;
                Refresh();
            }
        }

        private void Refresh()
        {
            UpdateContentHeight();
            int visibleCount = Math.Clamp(_dataModel.Count - _currentStartIndex, 0, _maxItemCount);

            for (int i = 0; i < _itemViews.Count; i++)
            {
                var view = _itemViews[i];
                if (i < visibleCount)
                {
                    view.GameObject.SetActive(true);
                    string text = _dataModel.Get(_currentStartIndex + i);
                    view.TextComponent.text = text;
                    view.Rect.anchoredPosition = new Vector2(0, -(_currentStartIndex + i) * _itemHeightWithPadding - _itemPadding / 2);
                }
                else
                {
                    view.GameObject.SetActive(false);
                }
            }
        }

        private void UpdateContentHeight()
        {
            float height = _dataModel.Count * _itemHeightWithPadding;
            _content.sizeDelta = new Vector2(_content.sizeDelta.x, height);
        }

        private void ResetScrollToBottom()
        {
            _scrollRect.verticalNormalizedPosition = 0f;
        }

        private void ResetScrollToTop()
        {
            _scrollRect.verticalNormalizedPosition = 1f;
            _currentStartIndex = 0;
        }
    }
}