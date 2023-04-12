using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Variables;

public class Unit : MonoBehaviour
{
    
    protected Vector3 target; 
    public float speed;
    public Team thisTeam;
    protected GameObject attackTarget;
    protected enum Command{Idle, Move, Attack, Collect};
    protected Command currentCommand;
    public int health = 100;
    public int strength = 10;
    public int attackRate = 2;
    bool takeDamage = false;
    void Start()
    {
        
        target = transform.position;

    }

    
    // Update is called once per frame
    void Update()
    {
        var step =  speed * Time.deltaTime;
        switch(currentCommand){
            case Command.Move:
                if(transform.position != target){
                    transform.position = Vector3.MoveTowards(transform.position, target, step);
                }
                break;
            case Command.Attack:
                if(Vector3.Distance(target, transform.position) > 5){
                    transform.position = Vector3.MoveTowards(transform.position, target, step);
                }
                else{
                    PerformAttack();
                }
                break;
            default:
                break;
            

        }
        if(health <= 0){
            Destroy(gameObject);
        }
        if(takeDamage){
            resetOutlineColour();
        }

    }

    public void MoveTo(Vector3 movePos){
        currentCommand = Command.Move;
        target = new Vector3(movePos.x, transform.position.y, movePos.z);
    }

    public void Attack(GameObject targetUnit){
        currentCommand = Command.Attack;
        target = new Vector3(targetUnit.transform.position.x, transform.position.y, targetUnit.transform.position.z);
        attackTarget = targetUnit;
    }

    float attackTime = 0.0F;
    public void PerformAttack(){
        attackTime = attackTime + Time.deltaTime;
        if(attackTarget == null){
            currentCommand = Command.Idle;
        }
        else if(attackTime > attackRate && attackTarget){
            attackTarget.GetComponent<Unit>().RecieveAttack(strength);
            attackTime = 0.0F;
        }
    }

    public void RecieveAttack(int damage){
        Debug.Log("Recieve Attack");
        health -= damage;
        setOutlineColour(Color.red);
        takeDamage = true;
    }

    public void Select(){
        setOutlineColour(Color.yellow);
    }

    public void Unselect(){
        setOutlineColour(Color.black);
    }

    public void setOutlineColour(Color colour){
        var renderer = gameObject.GetComponent<Renderer>();
        renderer.material.SetColor("_OutlineColor", colour);
    }

    float outlineCooldown = 0.0F;
    float cooldownRate = 0.2F;
    public void resetOutlineColour(){
        outlineCooldown = outlineCooldown + Time.deltaTime;

        if(outlineCooldown > cooldownRate){
            setOutlineColour(Color.black);
            takeDamage = false;
            setOutlineColour(Color.black);
            outlineCooldown = 0.0F;
        }
        
    }

    public Team getTeam(){
        return thisTeam;
    }
}