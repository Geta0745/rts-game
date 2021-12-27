using System.Collections.Generic;
using UnityEngine;

public class UnitSelecions : MonoBehaviour
{
    public List<GameObject> unitList = new List<GameObject>();
    public List<GameObject> unitSelected = new List<GameObject>();

    private static UnitSelecions _instance;
    public static UnitSelecions Instance {get {return _instance;}}

    private void Awake() {
        //If an instance of this already exists and it isn't this one
        if(_instance != null && _instance != this){
            //destroy this instance
            Destroy(this.gameObject);
        }else{
            //make an instance
            _instance = this;
        }
    }

    public void ClickSelect(GameObject unitToAdd){
        DeselectAll();
        unitSelected.Add(unitToAdd);
        unitToAdd.GetComponent<Outline>().enabled = true;
        unitToAdd.GetComponent<UnitMovement>().enabled = true;
    }

    public void ShifClickSelect(GameObject unitToAdd){
        if(!unitSelected.Contains(unitToAdd)){
            unitSelected.Add(unitToAdd);
            unitToAdd.GetComponent<Outline>().enabled = true;
            unitToAdd.GetComponent<UnitMovement>().enabled = true;
        }else{
            unitToAdd.GetComponent<Outline>().enabled = false;
            unitToAdd.GetComponent<UnitMovement>().enabled = false;
            unitSelected.Remove(unitToAdd);
        }
    }

    public void DragSelect(GameObject unitToAdd){
        if(!unitSelected.Contains(unitToAdd)){
            unitSelected.Add(unitToAdd);
            unitToAdd.GetComponent<Outline>().enabled = true;
            unitToAdd.GetComponent<UnitMovement>().enabled = true;
        }
    }

    public void DeselectAll(){
        foreach(var unit in unitSelected){
            unit.GetComponent<Outline>().enabled = false;
            unit.GetComponent<UnitMovement>().enabled = false;
        }
        unitSelected.Clear();
    }

    public void Deselect(GameObject unitToDeselect){
        
    }
}