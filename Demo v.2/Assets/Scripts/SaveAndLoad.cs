using UnityEngine;
using System.Collections;

public class SaveAndLoad : MonoBehaviour
{

    public void SavePosition() //sparar positionerna
    {
        PlayerPrefs.SetFloat("PlayerX", transform.position.x); //sparar spelarens x-position
        PlayerPrefs.SetFloat("PlayerY", transform.position.y); //sparar spelarens y-position

    }

    public void LoadPosition()
    {
        float x = PlayerPrefs.GetFloat("PlayerX"); //hämtar spelarens x-position
        float y = PlayerPrefs.GetFloat("PlayerY"); //hämtar spelarens y-position

        transform.position = new Vector3(x, y); //sätter spelarens pos till den sparade posen.
    }	
}

