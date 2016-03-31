using UnityEngine;
using System.Collections;

public class CameraFollwing : MonoBehaviour {

    public Transform target;
    Camera cam;
    float zoomOut = 80f; // mindre värde = större ut zoomning
	void Start () 
    {
        cam = GetComponent<Camera>();
	}
	
	// Update is called once per frame
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
