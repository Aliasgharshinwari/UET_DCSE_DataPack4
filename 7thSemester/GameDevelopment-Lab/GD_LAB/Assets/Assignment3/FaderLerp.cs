using System.Collections;
using UnityEngine;

public class FaderLerp : FaderBase
{
    public override void FadeIn(){
        StartCoroutine(_FadeIn());
    }

    public override void FadeOut(){
        StartCoroutine(_FadeOut());
    }

    private IEnumerator _FadeIn(){
        float elapsedTime = 0f; 
        float duration = 1f; 
        Color panelColor = panel.color;

        float startAlpha = 0f;
        float endAlpha = 1f;

        while (elapsedTime < duration){
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(startAlpha, endAlpha, elapsedTime / duration); // Smoothly interpolate alpha
            panelColor.a = alpha;
            panel.color = panelColor;
            yield return null;
        }

        panelColor.a = endAlpha;
        panel.color = panelColor;
    }

    private IEnumerator _FadeOut(){
        float elapsedTime = 0f; 
        float duration = 1f; 
        Color panelColor = panel.color;

        float startAlpha = 1f;
        float endAlpha = 0f;
        float alpha;
        while (elapsedTime < duration){
            elapsedTime += Time.deltaTime;
            alpha = Mathf.Lerp(startAlpha, endAlpha, elapsedTime / duration); // Smoothly interpolate alpha
            panelColor.a = alpha;
            panel.color = panelColor;
            yield return null;
        }
        panelColor.a = endAlpha;
        panel.color = panelColor;
    }
}
