using System;
using UnityEngine;
using UnityEngine.UI;
namespace HomeWork.UI 
{
    public class StartUIManager : MonoBehaviour
    {
        public event Action OnStartRequested;
        [SerializeField] Canvas _canvas;
        [SerializeField] Button _startButton;
        public void Initialize()
        {
            _startButton.onClick.AddListener(() => OnStartRequested?.Invoke());
        }

        public void OpenSceneUI(bool open)
        {
            _canvas.gameObject.SetActive(open);
        }
        private void OnDestroy()
        {
            _startButton.onClick.RemoveAllListeners();
        }
    }
}
