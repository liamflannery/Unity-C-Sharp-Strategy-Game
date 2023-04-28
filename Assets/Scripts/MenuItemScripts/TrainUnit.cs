using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TrainUnit : MenuItem
{
    GameObject spawnPoint;
    protected GameObject unitToTrain;
    protected int unitCost;
    protected void Awake(){
        //spawnPoint = parentBuilding.transform.Find("Spawn").gameObject;
    }

    public override void OnClick(){
        if(ResourceManager.Instance.getResources() >= unitCost){
            Instantiate(unitToTrain);
            ResourceManager.Instance.removeResources(unitCost);
        }
    }
}