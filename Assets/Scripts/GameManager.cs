using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Variables;

public class GameManager : MonoBehaviour {
    private static GameManager instance;
    bool paused = false;
    public static GameManager Instance {get {return instance;}}
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        } else {
            instance = this;
        }
    }

    void Update(){
        if(Input.GetButtonDown("Cancel") & paused){
            UnpauseGame();
        }
    }

    public void PauseGame(float time){
        Camera.main.GetComponent<Selector>().enabled = false; 
        Camera.main.GetComponent<CameraController>().enabled = false; 
        Time.timeScale = time;
        paused = true;
    }

    public void UnpauseGame(){
        Camera.main.GetComponent<Selector>().enabled = true; 
        Camera.main.GetComponent<CameraController>().enabled = true; 
        Time.timeScale = 1;
        paused = false;
    }




}