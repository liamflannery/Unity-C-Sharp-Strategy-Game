using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Variables;

public class GroundUnit : Unit
{
   
    // Start is called before the first frame update
    void Awake(){
        maxHealth = Variables.groundUnitHealth;
        strength = Variables.groundUnitStrength;
        attackRate = Variables.groundUnitAttackRate;
        speed = Variables.groundUnitSpeed;
    }
    

    
}
