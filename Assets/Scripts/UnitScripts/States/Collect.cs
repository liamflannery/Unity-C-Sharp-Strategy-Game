using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour
{
    // Start is called before the first frame update

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PerformCollect();
    }

    float interactTime = Mathf.Infinity;
    GameObject collectTarget;
    public bool PerformCollect(){
        
        interactTime = interactTime + Time.deltaTime;
        if(collectTarget == null){ 
            return false;
        }
        if(Vector3.Distance(transform.position, collectTarget.transform.position) > 2){
            return false;
        }
        if(interactTime > Variables.collectRate && collectTarget){
            collectTarget.GetComponent<SupplyCrate>().Collect();
            interactTime = 0.0F;
            return true;
        }
        return false;

    }

    public void setTarget(GameObject target){
        collectTarget = target;
    }
    public void resetTarget(){
        collectTarget = null;
    }
    
}
