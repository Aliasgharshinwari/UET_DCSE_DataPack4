using System.Collections;
using UnityEngine;

public class FaderSimple : FaderBase
{
    public override void FadeIn(){
        StartCoroutine(_FadeIn());
    }
    public override void FadeOut(){
        StartCoroutine(_FadeOut());
    }

    IEnumerator _FadeIn(){
        float alpha = 0f; 
        Color panelColor = panel.color; 

        panelColor.a = alpha;
        panel.color = panelColor;

        while (alpha < 1f) {
            alpha += 0.01f; 
            panelColor.a = alpha; 
            panel.color = panelColor; 
            yield return new WaitForSeconds(0.01f); 
        }

        panelColor.a = 1f;
        panel.color = panelColor;
    }

    IEnumerator _FadeOut(){
        float alpha = 1f; 
        Color panelColor = panel.color; 
        panelColor.a = alpha;
        panel.color = panelColor;

        while (alpha > 0) {
            alpha -= 0.01f; 
            panelColor.a = alpha; 
            panel.color = panelColor; 
            yield return new WaitForSeconds(0.01f); 
        }
        panelColor.a = 0f;
        panel.color = panelColor;
    }
}