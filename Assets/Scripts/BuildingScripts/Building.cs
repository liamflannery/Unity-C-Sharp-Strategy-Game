using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject blankMenuCanvas;
    public GameObject blankMenu;
    public List<MenuItem> menuItems;
    
    void Start()
    {
        blankMenuCanvas = Instantiate(Resources.Load("Blank_Menu_Canvas", typeof(GameObject))) as GameObject;
        blankMenu = blankMenuCanvas.transform.Find("Blank_Menu").gameObject;
        blankMenuCanvas.transform.Find("Grey_Out").gameObject.GetComponent<MenuItem>().SetBuilding(this);
        SetMenuItems();
        
        
        
        
       
        foreach(MenuItem item in blankMenu.GetComponentsInChildren<MenuItem>()){
            item.SetBuilding(this);
        }
        blankMenuCanvas.SetActive(false);
    }


    private void SetMenuItems()
    {
        for(int i = 0; i < menuItems.Count; i++){
                menuItems[i].SetSlot(blankMenu.transform.GetChild(i).gameObject);            
        }
    }

    // Update is called once per frame


    public void OpenMenu(){
        blankMenuCanvas.SetActive(true);
        GameManager.Instance.PauseGame(0.1F);
    }
    public void CloseMenu(){
        blankMenuCanvas.SetActive(false);
        GameManager.Instance.UnpauseGame();
    }

    public void DestroyBuilding(){
        Destroy(blankMenuCanvas);
        Destroy(gameObject);
    }
}
