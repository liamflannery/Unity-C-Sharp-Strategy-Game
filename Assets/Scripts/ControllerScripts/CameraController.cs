using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {   
        initialCameraPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        ZoomHandler();
    }

    void LateUpdate(){
        MoveHandler();
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

    Vector3 mouseOrigin;
    Vector3 difference;
    Vector3 initialCameraPos;
    Vector3 cameraMove;
    bool drag = false;
    public int dragSpeed;
    
    void MoveHandler(){
       if(Input.GetMouseButton(0)){
            difference = (Camera.main.ScreenToWorldPoint(Input.mousePosition)) - Camera.main.transform.position;
            if(!drag){
                drag = true;
                mouseOrigin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                
            }
       }
       else{
            drag = false;
       }
       
       if(drag){
            transform.position = mouseOrigin - difference;
       }
        

       
    }
}
