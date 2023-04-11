using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Variables;

public interface Unit
{
    

    public void MoveTo(Vector3 position){

    }
    public void Select(){

    }
    public void Unselect(){
        
    }

    public Team getTeam(){
        return Team.Player;    
    }

    public void Attack(GameObject target){
        
    }
}