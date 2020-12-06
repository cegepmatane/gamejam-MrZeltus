using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInOut : MonoBehaviour
{
    public Image blackFade;

    public void Start()
    {
        blackFade.canvasRenderer.SetAlpha(1.0f);
        fadeOut(2);

    }
    public IEnumerator Fade()
    {
        fadeIn(1);
        yield return new WaitForSeconds(1f);
        fadeOut(1);
    }
    public void fadeIn(int time)
    {
        blackFade.CrossFadeAlpha(1, time, false);
    }
    public void fadeOut(int time)
    {
        blackFade.CrossFadeAlpha(0, time, false);
    }
}
