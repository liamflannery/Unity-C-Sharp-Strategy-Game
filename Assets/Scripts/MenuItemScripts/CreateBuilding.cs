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

    public new void Update(){
        base.Update();
        if(ResourceManager.Instance.getResources() >= buildingCost){
            SetImage(new Color(1,1,1, alphaValue));
        }
        else{
            SetImage(new Color(1,1,1, 0.2f));
        }
        
    }
    

}