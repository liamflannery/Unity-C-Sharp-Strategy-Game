using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using static Variables;
public class Selector : MonoBehaviour
{
    public GameObject cursor;

    Vector2 mousePos = new Vector2();
    Camera cam;
    Vector3 point = new Vector3();
    List<Unit> selectedUnits = new List<Unit>();
  

    // Start is called before the first frame update
    void Start()
    {
        cam = gameObject.GetComponent<Camera>();
        //selectedUnits.Add(humanPlatoon);
    }

    // Update is called once per frame
    double mouseDownTime;
    void Update()
    {
        if(Input.GetMouseButtonDown(1)){
            Action();
        }
        if(Input.GetMouseButtonDown(0)){
            mouseDownTime = Time.fixedUnscaledTimeAsDouble;
        }
        if(Input.GetMouseButtonUp(0) && (Time.fixedUnscaledTimeAsDouble - mouseDownTime  <= 0.5)){
            ObjectSelector();
        }
        if(Input.GetButton("Fire1")){
            SelectAll();
        }
    }

    string actionTag;
    GameObject selectedObject;
    void Action(){

        RaycastHit hit = Caster();
        cursor.transform.position = hit.point;
        selectedObject = hit.collider.gameObject;
        actionTag = selectedObject.tag;
        switch(actionTag){
            case "Unit":
                if(selectedObject.GetComponent<Unit>().getTeam() == Team.Player){
                    SelectedUnitsMove(hit.point);
                }
                else{
                    SelectedUnitsAttack(selectedObject);
                }
                break;
            case "Supply":
                SelectedUnitsCollect(selectedObject);
                break;
            default:
                SelectedUnitsMove(hit.point);
                break;
                
        }
        

        
        
        UnselectAll();
    }

    RaycastHit hit;
    GameObject castedObject;
    string castedTag;
    void ObjectSelector(){
        hit = Caster();
        castedObject = hit.collider.gameObject;
        castedTag = castedObject.tag;
        if(castedTag == "Unit"){
            Unit selectedUnit = castedObject.GetComponent<Unit>();
            if(selectedUnit.getTeam() == Team.Player){
                if(selectedUnits.Contains(selectedUnit)){
                UnselectUnit(selectedUnit);
                }
                else{
                    SelectUnit(selectedUnit);
                }
            }
            

        }
        else{
            UnselectAll();
        }

        if(castedTag == "Building"){
            castedObject.GetComponent<Building>().OpenMenu();
        }
        
    }
    void OpenMenu(GameObject building){
        building.GetComponent<Building>().OpenMenu();
    }
    void SelectUnit(Unit unit){
        if(!(selectedUnits.Contains(unit))){
            selectedUnits.Add(unit);
            unit.Select();
        }

    }
    void UnselectUnit(Unit unit){
        unit.Unselect();
        selectedUnits.Remove(unit);
    }
    void UnselectAll(){
        
        foreach(Unit unit in selectedUnits){
            unit.Unselect();
        }
        selectedUnits.Clear();
    }

    void SelectAll(){
        var foundUnits = FindObjectsOfType<MonoBehaviour>().OfType<Unit>();
        foreach(Unit unit in foundUnits){
            if(unit.getTeam() == Team.Player){
                SelectUnit(unit);
            }
        }
    }

    void SelectedUnitsMove(Vector3 movePos){
        foreach(Unit unit in selectedUnits){
            unit.RecieveMoveCommand(movePos);
        }
    }

    void SelectedUnitsAttack(GameObject toAttack){
        foreach(Unit unit in selectedUnits){
            unit.RecieveAttackCommand(toAttack);
        }
    }

    void SelectedUnitsCollect(GameObject toCollect){
        foreach(Unit unit in selectedUnits){
            unit.RecieveCollectCommand(toCollect);
        }
    }

    RaycastHit Caster(){
        RaycastHit hit;
        Vector3 mousePosition = Input.mousePosition;
        mousePos.x = mousePosition.x;
        mousePos.y = (mousePosition.y);

        point = cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, cam.nearClipPlane));
        if (Physics.Raycast(point, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity)){
            Debug.DrawRay(point, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
        }
        return hit;
    }

    
}
