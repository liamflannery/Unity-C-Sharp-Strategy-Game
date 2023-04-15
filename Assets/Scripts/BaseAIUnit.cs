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
        GetComponent<SphereCollider>().radius = Variables.baseAISense;
    }
    // Update is called once per frame
    void Update()
    {
        base.Update();
        
    }

    private void OnTriggerEnter(Collider unitCollider){
        // if(unitCollider.gameObject.tag == "Unit"){
        //     Unit unit = unitCollider.gameObject.GetComponent<Unit>();
        //     if(unit.getTeam() == Variables.Team.Player){
        //         RecieveAttackCommand(unitCollider.gameObject);
        //     }
        //     Debug.Log("enter");
        // }
        
    }
}
