using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CreateTrainingHall : CreateBuilding
{
    private void Awake() {
        imgName = "TrainingHallImg";
        buildingToAdd = Resources.Load("Training_Hall") as GameObject;
        buildingCost = Variables.trainingHallCost;
    }
    
    
    

}