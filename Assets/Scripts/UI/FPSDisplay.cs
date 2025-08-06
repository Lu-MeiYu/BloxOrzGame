using TMPro;
using UnityEngine;
namespace HomeWork.UI
{
    public class FPSDisplay : MonoBehaviour
    {
        [SerializeField] private TMP_Text fpsText;
        private int count;
        private float deltaTime;
        private const int UpdateRate = 30;

        private void Awake()
        {
            if (fpsText == null) 
            {
                Debug.LogError($"{nameof(FPSDisplay)} TMP_Text¤£¥i¬°null!");
            }
            DontDestroyOnLoad(this);
        }
        private void Update()
        {
            count++;
            deltaTime += Time.deltaTime;

            if (count == UpdateRate)
            {
                count = 0;
                float fps = UpdateRate / deltaTime;
                deltaTime = 0;
                fpsText.text = $"FPS: {Mathf.Floor(fps)}";
            }
        }
    }
}
