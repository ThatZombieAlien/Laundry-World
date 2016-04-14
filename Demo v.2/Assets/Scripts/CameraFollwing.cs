using UnityEngine;
using System.Collections;

public class CameraFollwing : MonoBehaviour {

    public Transform target;
    Camera cam;
    float zoomOut = 80f; // mindre värde = större ut zoomning

    public bool bounds;
    public Vector3 minCameraPos;
    public Vector3 maxCameraPos;

	void Start () 
    {
        cam = GetComponent<Camera>();
	}

	void Update () 
    {
        cam.orthographicSize = (Screen.height / zoomOut) / 4f;  

        if(target)
        {
            transform.position = Vector3.Lerp(transform.position, target.position, 0.5f) + new Vector3(0, 0, -10);
            // Lerp: (från, till, fart)
        }

        if (bounds)
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, minCameraPos.x, maxCameraPos.x),
                Mathf.Clamp(transform.position.y, minCameraPos.y, maxCameraPos.y),
                Mathf.Clamp(transform.position.z, minCameraPos.z, maxCameraPos.z));
        }
	}
}
