using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Variables;

public class GroundUnit : MonoBehaviour, Unit
{
    Vector3 target; 
    public float speed;
    public Team thisTeam;
    GameObject attackTarget;
    enum Command{Idle, Move, Attack, Collect};
    Command currentCommand;
    // Start is called before the first frame update
    void Start()
    {
        
        target = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        var step =  speed * Time.deltaTime;
        Debug.Log("Current Command: " + currentCommand);
        switch(currentCommand){
            case Command.Move:
                if(transform.position != target){
                    transform.position = Vector3.MoveTowards(transform.position, target, step);
                }
                break;
            case Command.Attack:
                Debug.Log("Distance:" + Vector3.Distance(target, transform.position));
                if(Vector3.Distance(target, transform.position) > 5){
                    transform.position = Vector3.MoveTowards(transform.position, target, step);
                }
                else{
                    Debug.Log("attack");
                }
                break;
            default:
                break;
            

        }

    }

    public void MoveTo(Vector3 movePos){
        currentCommand = Command.Move;
        target = new Vector3(movePos.x, transform.position.y, movePos.z);
    }

    public void Attack(GameObject targetUnit){
        Debug.Log("recieved attack command");
        currentCommand = Command.Attack;
        target = new Vector3(targetUnit.transform.position.x, transform.position.y, targetUnit.transform.position.z);
        attackTarget = targetUnit;
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

    public Team getTeam(){
        return thisTeam;
    }
}
