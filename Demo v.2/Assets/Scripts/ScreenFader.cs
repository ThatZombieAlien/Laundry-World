using UnityEngine;
using System.Collections;

public class ScreenFader : MonoBehaviour {

    Animator anim;
    bool isFading = false;

	void Start ()
    {
        anim = GetComponent<Animator>();
	}
	
    public IEnumerator FadeToClear()
    {
        isFading = true;
        anim.SetTrigger("FadeIn");

        while (isFading)
            yield return null;
    }

    public IEnumerator FadeToBlack()
    {
        isFading = true;
        anim.SetTrigger("FadeOut");

        while (isFading)
            yield return null;
    }

    void AnimationComplete()
    {
        isFading = false;
    }
    // klassen där händelsen då faden ska ske kallar på de olika metodernq (se warp-klassen)
    // Animationerna har ett 'AnimationComplete' stadie, som sker då animationen är klar vilket 
    //gör så att koden hoppar ur metoden och slutar fadea.
}
