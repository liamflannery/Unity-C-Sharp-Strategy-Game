using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyBuildingTile : Building
{
    #pragma warning disable 1234
    void Awake() {
        menuItems = new List<MenuItem>();
        menuItems.Add(new BlankSlot()); //slot 1
        menuItems.Add(new CreateTrainingHall()); // slot 2
        menuItems.Add(new CreateSupplyPad()); //slot 3
        menuItems.Add(new BlankSlot()); // slot 4
        menuItems.Add(new BlankSlot()); //slot 5
        menuItems.Add(new BlankSlot()); // slot 6
        menuItems.Add(new BlankSlot()); //slot 7
        menuItems.Add(new BlankSlot()); // slot 8
    }
    
}
