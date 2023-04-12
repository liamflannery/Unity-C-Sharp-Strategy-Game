using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Variables;

public class Supply : MonoBehaviour
{
    public int resourceNumber = 100;

    public void Collect(){
        resourceNumber -= 10;
        ResourceManager.Instance.addResources(10);
    }

    void Update(){
        if(resourceNumber <= 0){
            Destroy(gameObject);
        }
    }
}