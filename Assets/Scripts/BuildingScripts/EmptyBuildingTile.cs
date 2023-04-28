using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyBuildingTile : Building
{
    void Awake() {
        menuItems = new List<MenuItem>();
        menuItems.Add(new CreateSupplyPad());
        menuItems.Add(new CreateTrainingHall());
    }
    
}
