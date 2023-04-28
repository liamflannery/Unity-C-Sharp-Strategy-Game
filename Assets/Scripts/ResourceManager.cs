using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Variables;

public class ResourceManager : MonoBehaviour {
    private static ResourceManager instance;
    public static ResourceManager Instance {get {return instance;}}
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        } else {
            instance = this;
        }
    }



    public int resources = 0;

    public void addResources(int amount){
        resources += amount;
    }

    public void removeResources(int amount){
        resources -= amount;
    }
}