//Script skrivet av Maria Görman
using UnityEngine;
using System.Collections;

public class Save : MonoBehaviour
{

    public void SavePosition()
    {
        PlayerPrefs.SetFloat("PlayerX", transform.position.x);
        PlayerPrefs.SetFloat("PlayerY", transform.position.y);

    }

    public void LoadPosition()
    {
        float x = PlayerPrefs.GetFloat("PlayerX");
        float y = PlayerPrefs.GetFloat("PlayerY");

        transform.position = new Vector3(x, y);
    }	
}

