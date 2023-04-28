using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static Variables;

public class Unit : HasHealth
{
    
    protected Vector3 target; 
    public float speed;
    public Team thisTeam;
    protected GameObject attackTarget;
    protected GameObject collectTarget;
    public enum Command{Idle, Move, Attack, Collect};
    public Command currentCommand;
    public int strength;
    public static int attackRate;
    GameObject iconCanvas;
    GameObject attackIcon;
    GameObject collectIcon;
    bool takeDamage = false;
    public Color hurtColour = Color.red;
    public Color selectedColour = Color.yellow;
    protected int angularSpeed = Variables.navigationAngularSpeed;
    new void Start()
    {
        base.Start();
        iconCanvas = Instantiate(Resources.Load("Icons", typeof(GameObject))) as GameObject;
        iconCanvas.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        iconCanvas.transform.SetParent(gameObject.transform);
        attackIcon = iconCanvas.transform.GetChild(0).gameObject;
        collectIcon = iconCanvas.transform.GetChild(1).gameObject;
        attackIcon.SetActive(false);
        collectIcon.SetActive(false);
        target = transform.position;
        navAgent = GetComponent<NavMeshAgent>();
        navAgent.speed = speed;
        navAgent.angularSpeed = angularSpeed;

    }

    
    // Update is called once per frame
    protected virtual new void Update()
    {
        base.Update();
        switch(currentCommand){
            case Command.Move:
                navigateTo(target, 1);
                break;
            case Command.Attack:
                if(!navigateTo(target, 4)){
                    attackIcon.SetActive(true);
                    PerformAttack();
                }
                break;
            case Command.Collect:
                if(!navigateTo(target, 4)){
                    collectIcon.SetActive(true);
                    PerformCollect();
                }
                break;
            default:
                break;
            

        }

        if(takeDamage){
            resetOutlineColour();
        }
        if(currentCommand != Command.Attack && attackIcon.activeSelf){
            attackIcon.SetActive(false);
        }
        if(currentCommand != Command.Collect && collectIcon.activeSelf){
            collectIcon.SetActive(false);
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

    public void RecieveIdleCommand(){
        currentCommand = Command.Idle;
        target = gameObject.transform.position;
        navigateTo(target, 0);
    }

    public void RecieveAttack(int damage){
        currentHealth -= damage;
        setOutlineColour(hurtColour);
        takeDamage = true;
    }

    float attackTime = Mathf.Infinity;
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

    float interactTime = Mathf.Infinity;
    public void PerformCollect(){
        interactTime = interactTime + Time.deltaTime;
        if(collectTarget == null){
            currentCommand = Command.Idle;
        }
        else if(interactTime > Variables.collectRate && collectTarget){
            collectTarget.GetComponent<SupplyCrate>().Collect();
            interactTime = 0.0F;
        }
    }

    public void Select(){
        setOutlineColour(selectedColour);
    }

    public void Unselect(){
        setOutlineColour(Color.black);
    }

    public void setOutlineColour(Color colour){
        
        if(gameObject.GetComponent<Renderer>()){
            setRendererOutline(gameObject, colour);
        }
        else{
            if(transform.childCount > 0){
                for(int i = 0; i < transform.childCount; i++){
                    if(transform.GetChild(i).GetComponent<Renderer>()){
                        setRendererOutline(transform.GetChild(i).gameObject, colour);
                    }
                }
            }
        }
        
    }

    public void setRendererOutline(GameObject toSet, Color colour){
            var renderer = toSet.GetComponent<Renderer>();
            renderer.material.SetColor("_OutlineColor", colour);
    }

    NavMeshAgent navAgent; 
    public bool navigateTo(Vector3 destination, int stoppingDistance){
        var step =  speed * Time.deltaTime;
        if(Vector3.Distance(destination, transform.position) > stoppingDistance){
            if(navAgent.destination != destination){
                navAgent.SetDestination(destination);
            }
            return true;
        }
        else{
            navAgent.SetDestination(transform.position);
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