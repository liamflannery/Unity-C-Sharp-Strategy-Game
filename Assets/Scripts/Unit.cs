using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Variables;

public class Unit : HasHealth
{
    
    protected Vector3 target; 
    public float speed;
    public Team thisTeam;
    protected GameObject attackTarget;
    protected GameObject collectTarget;
    protected enum Command{Idle, Move, Attack, Collect};
    protected Command currentCommand;
    public int strength = 10;
    public int attackRate = 2;
    
    bool takeDamage = false;
    void Start()
    {
        base.Start();
        target = transform.position;

    }

    
    // Update is called once per frame
    void Update()
    {
        base.Update();
        switch(currentCommand){
            case Command.Move:
                navigateTo(target, 0);
                break;
            case Command.Attack:
                if(!navigateTo(target, 5)){
                    PerformAttack();
                }
                break;
            case Command.Collect:
                if(!navigateTo(target, 5)){
                    PerformCollect();
                }
                break;
            default:
                break;
            

        }

        if(takeDamage){
            resetOutlineColour();
        }

    }

    public void RecieveMoveCommand(Vector3 movePos){
        currentCommand = Command.Move;
        target = new Vector3(movePos.x, transform.position.y, movePos.z);
    }

    public void RecieveAttackCommand(GameObject targetUnit){
        currentCommand = Command.Attack;
        target = new Vector3(targetUnit.transform.position.x, transform.position.y, targetUnit.transform.position.z);
        attackTarget = targetUnit;
    }
    
    public void RecieveCollectCommand(GameObject targetUnit){
        currentCommand = Command.Collect;
        target = new Vector3(targetUnit.transform.position.x, transform.position.y, targetUnit.transform.position.z);
        collectTarget = targetUnit;
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
        currentHealth -= damage;
        setOutlineColour(Color.red);
        takeDamage = true;
    }

    float interactTime = 0.0F;
    public void PerformCollect(){
        interactTime = interactTime + Time.deltaTime;
        if(collectTarget == null){
            currentCommand = Command.Idle;
        }
        else if(interactTime > Variables.collectRate && collectTarget){
            collectTarget.GetComponent<Supply>().Collect();
            interactTime = 0.0F;
        }
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

    public bool navigateTo(Vector3 destination, int stoppingDistance){
        var step =  speed * Time.deltaTime;
        if(Vector3.Distance(destination, transform.position) > stoppingDistance){
                    transform.position = Vector3.MoveTowards(transform.position, destination, step);
                    return true;
        }
        return false;
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