using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class MenuItem : MonoBehaviour
{
    public Building parentBuilding;
    protected string imgName;
    protected float alphaValue = 1.0F;

    void Start(){
        
        SetImage();
        if(GetComponent<EventTrigger>()){
            SetUpButtonClick();
        }
        
    }

    void Update() {
        if(Input.GetButtonDown("Cancel")){
            parentBuilding.CloseMenu();
        }
            
    }
    
    public void SetSlot(GameObject slot){
        slot.AddComponent(this.GetType());
    }

    void SetImage(){
        Image img = gameObject.GetComponent<Image>();
        Sprite sprite = Resources.Load<Sprite>(imgName);
        Debug.Log(sprite);
        img.sprite = sprite;
        var imgColor = img.color;
        imgColor.a = alphaValue;
        img.color = imgColor;
    }
   

    public void SetBuilding(Building inBuilding){
        parentBuilding = inBuilding;
    }

    public virtual void OnClick(){
        Debug.Log("menu item clicked");
    }

    void SetUpButtonClick(){
        EventTrigger trigger = GetComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerClick;
        entry.callback.AddListener( (eventData) => { this.OnClick(); } );
        trigger.triggers.Add(entry);
    }


    

}