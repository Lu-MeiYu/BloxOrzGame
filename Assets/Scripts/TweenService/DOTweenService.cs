
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
namespace HomeWork.TweenService
{
    public static class DoTweenService
    {
        private static IDoTweenService _instance = new TweenServiceAdapter();

        public static void SetImplementation(IDoTweenService implementation)
        {
            _instance = implementation;
        }

        public static IEnumerator FadeColor(Graphic graphic, Color from, Color to, float duration)
        {
            return _instance.FadeColor(graphic, from, to, duration);
        }

        public static IEnumerator FilledImage(Image image, float endValue, float duration)
        {
            return _instance.FilledImage(image, endValue, duration);
        }
    }
}