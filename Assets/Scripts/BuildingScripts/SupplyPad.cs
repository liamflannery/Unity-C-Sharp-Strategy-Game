using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupplyPad : Building
{
    int rate;
    int amount;
    void Awake() {
        menuItems = new List<MenuItem>();
        rate = Variables.supplyPadRate;
        amount = Variables.supplyPadAmount;
    }

    float thisTime = 0.0F;
    void Update(){
        thisTime += Time.deltaTime;
        if(thisTime > rate){
            ResourceManager.Instance.addResources(amount);
            thisTime = 0.0F;
        }
    }
    
}
