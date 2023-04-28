using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class TrainHumanPlatoon : TrainUnit
{

    private new void Awake() {
        base.Awake();
        imgName = "HumanPlatoonImg";
        unitCost = Variables.humanPlatoonCost;
        unitToTrain = Resources.Load("HumanPlatoon") as GameObject;

    }

 

}