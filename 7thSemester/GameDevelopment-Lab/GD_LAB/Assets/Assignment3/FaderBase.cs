using UnityEngine;
using UnityEngine.UI;

public abstract class FaderBase : MonoBehaviour
{
    [SerializeField]
    protected Image panel;
    [SerializeField]
    protected Button fadeInButton;
    [SerializeField]
    protected Button fadeOutButton;
    
    public abstract void FadeIn();

    public abstract void FadeOut();

     // Start is called before the first frame update
    void Awake()
    {
        if (panel == null)
            panel = GameObject.Find("Panel").GetComponent<Image>();
        
        fadeInButton.onClick.AddListener(FadeIn);
        fadeOutButton.onClick.AddListener(FadeOut);
    }

}
