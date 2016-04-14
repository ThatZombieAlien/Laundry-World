using UnityEngine;
using System.Collections;

public class WarpDoor : MonoBehaviour
{

    public Transform warpTarget;
    public AudioSource doorSound;

    IEnumerator OnTriggerEnter2D(Collider2D other)
    {
        ScreenFader sf = GameObject.FindGameObjectWithTag("Fader").GetComponent<ScreenFader>();

        doorSound.Play();

        yield return StartCoroutine(sf.FadeToBlack());

        Debug.Log("An object Collided");

        other.gameObject.transform.position = warpTarget.position;
        Camera.main.transform.position = warpTarget.position;

        yield return StartCoroutine(sf.FadeToClear());
    }
    // Spela ljud, Fade till svart, flyttar positionen på spelaren och kameran, fade till clear
}
