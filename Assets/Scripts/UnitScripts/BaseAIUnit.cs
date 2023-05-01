using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAIUnit : Unit
{
    // Start is called before the first frame update

    void Awake(){
        maxHealth = Variables.baseAIHealth;
        strength = Variables.baseAIStrength;
        attackRate = Variables.baseAIAttackRate;
        speed = Variables.baseAISpeed;
        thisTeam = Variables.Team.AI;
        angularSpeed = Variables.baseAIAngularSpeed;
        attackRange = Variables.baseAIAttackRange;
        sense = Variables.baseAISense;
    }
    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        DetectUnits();
        
    }



    void DetectUnits(){
        int layerMask = 1 << 7;
        Collider[] colliders = Physics.OverlapSphere(transform.position, sense, layerMask);
        if(colliders.Length == 0){
            RecieveIdleCommand();
        }
        for(int i = 0; i < colliders.Length; i++){
            if(colliders[i].gameObject.GetComponent<Unit>().getTeam() == Variables.Team.Player){
                Debug.Log("moving to target");
                RecieveMoveCommand(colliders[i].gameObject.transform.position);
                break;
            }
        }

    }
}
