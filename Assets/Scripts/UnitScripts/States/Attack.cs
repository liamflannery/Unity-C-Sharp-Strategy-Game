using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Variables;

public class Attack: MonoBehaviour
{
    protected GameObject attackTarget;
    public int strength;
    public static int attackRate;
    int attackRange;
    int accuracy;
    Unit unitScript;
    Team currentTeam;
    // Start is called before the first frame update
    void Start()
    {
        unitScript = GetComponent<Unit>();
        strength = unitScript.getStrength();
        attackRate = unitScript.getAttackRate();
        attackRange = unitScript.getAttackRange();
        accuracy = unitScript.getAccuracy();
        surroundingEnemies = new List<GameObject>();
        currentTeam = unitScript.getTeam();

    }

            
        
    // Update is called once per frame
    public List<GameObject> surroundingEnemies;
    void Update()
    {
        ScanForEnemies();
    }

    
    float attackTime;
    GameObject givenTarget;
    private void PerformAttack()
    {
        GameObject attackTarget = null;
        if(givenTarget && surroundingEnemies.Contains(givenTarget)){
            attackTarget = givenTarget;
        }
        else if(surroundingEnemies.Count > 0){
            attackTarget = surroundingEnemies[0];
        }
        attackTime = attackTime + Time.deltaTime;
        if(attackTime > attackRate && attackTarget){
            attackTarget.GetComponent<Unit>().RecieveAttack(strength);
            attackTime = 0.0F;
        }
    }

    // attackTime = attackTime + Time.deltaTime;
    // else if(attackTime > attackRate && attackTarget){
    //         attackTarget.GetComponent<Unit>().RecieveAttack(strength);
    //         attackTime = 0.0F;
    //     }

    int layerMask = 1 << 6 | 1 << 7;
    Collider[] surroundingUnits;
    List<Collider> surroundingUnitsList;
    void ScanForEnemies(){
        surroundingUnits = Physics.OverlapSphere(transform.position, attackRange, layerMask);
        surroundingEnemies = new List<GameObject>();
        if(surroundingUnits != null){
            for(int i = 0; i < surroundingUnits.Length; i++){
                if(surroundingUnits[i].gameObject.GetComponent<Unit>()){
                    if(!(surroundingUnits[i].gameObject.GetComponent<Unit>().getTeam() == currentTeam)){
                        if(!surroundingEnemies.Contains(surroundingUnits[i].gameObject)){
                            surroundingEnemies.Add(surroundingUnits[i].gameObject);
                        }
                    }
                }

            }
        }
        SortEnemies();
        PerformAttack();
        
    }

    void SortEnemies(){
        surroundingEnemies.Sort(SortByDistance);
    }

    private int SortByDistance(GameObject e1, GameObject e2)
    {
        float e1Distance = Vector3.Distance(e1.transform.position, gameObject.transform.position);
        float e2Distance = Vector3.Distance(e2.transform.position, gameObject.transform.position);
        return e1Distance.CompareTo(e2Distance);
    }

    internal void RecieveAttackUnit(GameObject targetUnit)
    {
       givenTarget = targetUnit;
    }

    internal void ResetAttackTarget(){
        givenTarget = null;
    }
}
