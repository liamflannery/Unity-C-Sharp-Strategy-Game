using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static Variables;

public class Unit : HasHealth
{
    
    new void Start()
    {
        base.Start();
        SetUpIcons();
        AddComponents();


    }

    protected virtual new void Update()
    {
        base.Update();
        if(takeDamage){
            resetOutlineColour();
        }
    }



    public void RecieveIdleCommand(){
        attack.ResetAttackTarget();
  
    }    
    
    public void RecieveMoveCommand(Vector3 movePos){
        attack.ResetAttackTarget();
        move.navigateTo(movePos, 2);
 
    }

    public void RecieveAttackCommand(GameObject targetUnit){
        attack.RecieveAttackUnit(targetUnit);
        move.navigateTo(targetUnit, sense);
     
    }
    
    public void RecieveCollectCommand(GameObject targetCrate){
        RecieveMoveCommand(targetCrate.transform.position);
        collect.setTarget(targetCrate);
      
    }





    public void RecieveAttack(int damage){
        currentHealth -= damage;
        setOutlineColour(hurtColour);
        takeDamage = true;
    }

    

    Attack attack;
    Move move;
    Collect collect;
    private void AddComponents(){
        move = gameObject.AddComponent<Move>();
        attack = gameObject.AddComponent<Attack>();
        collect = gameObject.AddComponent<Collect>();
    }
    
    
    public void Select(){
        setOutlineColour(selectedColour);
    }

    public void Unselect(){
        setOutlineColour(Color.black);
    }

    bool takeDamage;
    public Color hurtColour = Color.red;
    public Color selectedColour = Color.yellow;

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

    GameObject iconCanvas;
    GameObject attackIcon;
    GameObject collectIcon;
    private void SetUpIcons()
    {
        iconCanvas = Instantiate(Resources.Load("Icons", typeof(GameObject))) as GameObject;
        iconCanvas.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        iconCanvas.transform.SetParent(gameObject.transform);
        attackIcon = iconCanvas.transform.GetChild(0).gameObject;
        collectIcon = iconCanvas.transform.GetChild(1).gameObject;
        attackIcon.SetActive(false);
        collectIcon.SetActive(false);
    }


    protected int strength;
    protected int attackRate;
    protected int speed;
    protected int angularSpeed;
    protected int accuracy;
    protected int attackRange;
    protected int sense;
    public Team thisTeam;
    public Team getTeam(){
        return thisTeam;
    }

    internal float getSpeed()
    {
        return speed;
    }

    internal int getStrength()
    {
        return strength;
    }

    internal int getAttackRate()
    {
        return attackRate;
    }

    internal int getAttackRange()
    {
        return attackRange;
    }

    internal int getAccuracy()
    {
        return accuracy;
    }
    internal int getSense(){
        return sense;
    }
}