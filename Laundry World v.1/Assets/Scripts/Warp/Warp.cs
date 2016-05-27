﻿// Script skrivet av Sanna Gustafsson

using UnityEngine;
using System.Collections;

public class Warp : MonoBehaviour {

    public Transform warpTarget;

    IEnumerator OnTriggerEnter2D(Collider2D other)
    {
        ScreenFader sf = GameObject.FindGameObjectWithTag("Fader").GetComponent<ScreenFader>();

        yield return StartCoroutine(sf.FadeToBlack());

        other.gameObject.transform.position = warpTarget.position;
        UnityEngine.Camera.main.transform.position = warpTarget.position;

        yield return StartCoroutine(sf.FadeToClear());

        // Fade till svart, flyttar positionen på spelaren och kameran, fade till clear
    }
}
