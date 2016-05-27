// Script skrivet av Sanna Gustafsson

using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {

    public Transform target;
    UnityEngine.Camera cam;
    float zoomOut = 80f; // mindre värde = större ut zoomning

    public Vector3 minCameraPos;
    public Vector3 maxCameraPos;

	void Start () 
    {
        cam = GetComponent<UnityEngine.Camera>();
	}

	void Update () 
    {
        cam.orthographicSize = (Screen.height / zoomOut) / 4f;  

        if(target)
        {
            transform.position = Vector3.Lerp(transform.position, target.position, 0.5f) + new Vector3(0, 0, -10);
            // Lerp: (från, till, fart)
        }
	}
}
