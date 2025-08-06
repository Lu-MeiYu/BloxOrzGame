using System;
using System.Collections;
using UnityEngine;

namespace HomeWork.LoadScene
{
    /// <summary>
    /// ����Root��l�ƼҪO
    /// </summary>
    public abstract class SceneInitializer : MonoBehaviour
    {
        /// <summary>
        /// �b�����[����I�s
        /// </summary>
        public void Initialize(Action OnLoadFinish)
        {
            StartCoroutine(InitializeEnumerator(OnLoadFinish));
        }
        /// <summary>
        /// �����[����ALoading���O�����e�I�s
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
