using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Variables;

public class HumanPlatoon : Unit
{
   
    // Start is called before the first frame update
    void Awake(){
        maxHealth = Variables.humanPlatoonHealth;
        strength = Variables.humanPlatoonStrength;
        attackRate = Variables.humanPlatoonAttackRate;
        speed = Variables.humanPlatoonSpeed;
    }
    

    
}
