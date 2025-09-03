using System.Collections;
using UnityEngine;

public class FaderAnimationCurve : FaderBase
{
    [SerializeField] private AnimationCurve fadeCurve; 
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
        float t,alpha;
        while (elapsedTime < duration){
            elapsedTime += Time.deltaTime;
            t = Mathf.Clamp01(elapsedTime / duration);
            alpha = Mathf.Lerp(startAlpha, endAlpha, fadeCurve.Evaluate(t));
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
        while (elapsedTime < duration){
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / duration); 
            float alpha = Mathf.Lerp(startAlpha, endAlpha, fadeCurve.Evaluate(t)); 
            panelColor.a = alpha;
            panel.color = panelColor;
            yield return null;
        }
        panelColor.a = endAlpha;
        panel.color = panelColor;
    }
}