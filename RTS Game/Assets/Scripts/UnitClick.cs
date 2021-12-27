using UnityEngine;

public class UnitClick : MonoBehaviour
{
    private Camera myCam;

    public LayerMask clickable;
    public LayerMask ground;

    private void Start() {
        myCam = Camera.main;
    }

    private void Update() {
        if(Input.GetMouseButtonDown(0)){
            RaycastHit hit;
            Ray ray = myCam.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray,out hit , Mathf.Infinity , clickable)){
                //if hit clickable object
                if(Input.GetKey(KeyCode.LeftShift)){
                    UnitSelecions.Instance.ShifClickSelect(hit.collider.gameObject);
                }else{
                    UnitSelecions.Instance.ClickSelect(hit.collider.gameObject);
                }
            }else{
                //if not hit 
                if(Input.GetKey(KeyCode.LeftShift)){
                    UnitSelecions.Instance.DeselectAll();
                }
                
            }
        }
        if(Input.GetMouseButton(1)){
            UnitSelecions.Instance.DeselectAll();
        }
    }
}