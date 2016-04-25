using UnityEngine;
using System.Collections;

public class PlaySound : MonoBehaviour {

    public AudioSource sound;
    public bool playSound;
	void Start () 
    {
        //if (playSound)
        {
            sound.Play();
        }
	}	
}
