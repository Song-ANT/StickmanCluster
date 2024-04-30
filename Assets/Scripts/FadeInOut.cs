using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeInOut : MonoBehaviour
{
    public CanvasGroup canvasGroup;

    private FadeInOut _fadeInOut;

    public bool fadeIn;
    public bool fadeOut;

    public float TimeToFade;

    private void Start()
    {
        _fadeInOut = FindObjectOfType<FadeInOut>();
        _fadeInOut.FadeOut();
    }

    private void Update()
    {
        if (fadeIn)
        {
            if(canvasGroup.alpha < 1)
            {
                canvasGroup.alpha += TimeToFade * Time.unscaledDeltaTime;

                if(canvasGroup.alpha >= 1) fadeIn = false;
            }
            else fadeIn = false;
        }

        if (fadeOut)
        {
            if (canvasGroup.alpha > 0)
            {
                canvasGroup.alpha -= TimeToFade * Time.unscaledDeltaTime;

                if (canvasGroup.alpha <= 0) fadeOut = false;
            }
            else fadeOut = false;
        }
    }

    public void FadeIn()
    {
        fadeIn = true;
    }

    public void FadeOut()
    {
        fadeOut = true;
    }

    public IEnumerator ChangeScene(string sceneName)
    {
        FadeIn();
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(1);
        SceneManager.LoadScene(sceneName);
    }
}
