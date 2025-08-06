using System;
using System.Collections;
using UnityEngine;

namespace HomeWork.LoadScene
{
    /// <summary>
    /// 場景Root初始化模板
    /// </summary>
    public abstract class SceneInitializer : MonoBehaviour
    {
        /// <summary>
        /// 在場景加載後呼叫
        /// </summary>
        public void Initialize(Action OnLoadFinish)
        {
            StartCoroutine(InitializeEnumerator(OnLoadFinish));
        }
        /// <summary>
        /// 場景加載後，Loading面板關閉前呼叫
        /// </summary>
        /// <returns></returns>
        protected abstract IEnumerator OnSceneLoad();

        private IEnumerator InitializeEnumerator(Action OnLoadFinish)
        {
            yield return OnSceneLoad();
            OnLoadFinish?.Invoke();
        }
    }
}
