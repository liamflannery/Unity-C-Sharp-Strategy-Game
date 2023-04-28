using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingHall : Building
{
    void Awake() {
        menuItems = new List<MenuItem>();
        menuItems.Add(new BlankSlot()); //slot 1
        menuItems.Add(new TrainHumanPlatoon()); // slot 2
        menuItems.Add(new BlankSlot()); //slot 3
        menuItems.Add(new BlankSlot()); // slot 4
        menuItems.Add(new BlankSlot()); //slot 5
        menuItems.Add(new BlankSlot()); // slot 6
        menuItems.Add(new BlankSlot()); //slot 7
        menuItems.Add(new BlankSlot()); // slot 8
    }
    
}
