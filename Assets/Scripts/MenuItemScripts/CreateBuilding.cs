using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CreateBuilding : MenuItem
{
    protected GameObject buildingToAdd;
    protected int buildingCost;
    public override void OnClick(){
        if(ResourceManager.Instance.getResources() >= buildingCost){
            Instantiate(buildingToAdd, parentBuilding.transform.position, Quaternion.identity);
            ResourceManager.Instance.removeResources(buildingCost);
            parentBuilding.CloseMenu();
            parentBuilding.DestroyBuilding();
        }
    }
    

}