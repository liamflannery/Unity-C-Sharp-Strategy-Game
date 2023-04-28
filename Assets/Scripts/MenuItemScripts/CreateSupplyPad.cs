using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CreateSupplyPad : CreateBuilding
{
    private void Awake() {
        imgName = "SupplyPadImg";
        buildingToAdd = Resources.Load("Supply_Pad") as GameObject;
        buildingCost = Variables.supplyPadCost;
    }
    
    
    

}