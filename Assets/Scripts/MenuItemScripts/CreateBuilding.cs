using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CreateBuilding : MenuItem
{
    protected GameObject buildingToAdd;
    
    public override void OnClick(){
        Debug.Log("create building");
        Instantiate(buildingToAdd, parentBuilding.transform.position, Quaternion.identity);
        parentBuilding.CloseMenu();
        parentBuilding.DestroyBuilding();
    }
    

}