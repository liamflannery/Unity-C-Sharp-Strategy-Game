using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GreyOut : MenuItem
{
    void Awake(){
        alphaValue = 0.4F;
    }
    public override void OnClick(){
        parentBuilding.CloseMenu();
    }
    

}