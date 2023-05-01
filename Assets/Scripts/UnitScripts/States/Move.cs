using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Move : MonoBehaviour
{
    NavMeshAgent navAgent; 
    public float speed;

    protected int angularSpeed = Variables.navigationAngularSpeed;
    // Start is called before the first frame update
    void Start()
    {
        destination = transform.position;
        speed = GetComponent<Unit>().getSpeed();


        navAgent = GetComponent<NavMeshAgent>();
        navAgent.speed = speed;
        navAgent.angularSpeed = angularSpeed;
    }

    GameObject movingTarget;
    Vector3 destination;
    int stoppingDistance;
    // Update is called once per frame
    void Update()
    {
        if(movingTarget != null){
            destination = movingTarget.transform.position;
        }
        
        if(Vector3.Distance(destination, transform.position) > stoppingDistance){
            navAgent.SetDestination(destination);
        }
        else{
            navAgent.SetDestination(transform.position);
        }
    }



    public void navigateTo(Vector3 destination, int stoppingDistance){
       this.destination = destination;
       this.stoppingDistance = stoppingDistance;
       movingTarget = null;
    }

    public void navigateTo(GameObject movingTarget, int stoppingDistance){
       this.stoppingDistance = stoppingDistance;
       this.movingTarget = movingTarget;
    }
}
