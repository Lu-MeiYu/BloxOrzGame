using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace HomeWork.TweenService
{
    public class TweenServiceAdapter : IDoTweenService
    {
        public IEnumerator FadeColor(Graphic graphic, Color fromColor, Color toColor, float duration)
        {
            graphic.color = fromColor;
            Tweener tw = graphic.DOColor(toColor, duration);
            yield return tw.WaitForCompletion();
        }

        public IEnumerator FilledImage(Image image, float endValue, float duration)
        {
            yield return DOTween.To(() => image.fillAmount, x => image.fillAmount = x, endValue, duration).WaitForCompletion();
        }
    }
}
