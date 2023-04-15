using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ZoomHandler();       
    }

    void ZoomHandler(){
        if(5 <= Camera.main.orthographicSize && Camera.main.orthographicSize <= 40){
            Camera.main.orthographicSize -= Input.mouseScrollDelta.y;
        }
        if(Camera.main.orthographicSize < 5){
            Camera.main.orthographicSize = 5;
        }
        if(Camera.main.orthographicSize > 40){
            Camera.main.orthographicSize = 40;
        }
    }
}
