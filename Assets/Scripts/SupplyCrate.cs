using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Variables;

public class SupplyCrate : HasHealth
{
    void Awake(){
        maxHealth = 100;  
    }

    public void Collect(){
        currentHealth -= 10;
        ResourceManager.Instance.addResources(10);
    }


}