using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public interface IDoTweenService
{
    public IEnumerator FadeColor(Graphic graphic, Color fromColor, Color toColor, float duration);

    public IEnumerator FilledImage(Image image, float endValue, float duration);
}

