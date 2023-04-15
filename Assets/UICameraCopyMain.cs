using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICameraCopyMain : MonoBehaviour
{
    Camera thisCamera;
    // Start is called before the first frame update
    void Start()
    {
        thisCamera = gameObject.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        thisCamera.orthographicSize = Camera.main.orthographicSize;
        
    }
}
