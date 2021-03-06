using UnityEngine;

public class UnitDrag : MonoBehaviour
{
    Camera myCam;
    [SerializeField]
    RectTransform boxVisual;

    Rect selectionBox;
    Vector2 startPosition,endPosition;

    private void Start() {
        myCam = Camera.main;
        startPosition = Vector2.zero;
        endPosition = Vector2.zero;
        DrawVisual();
    }

    private void Update() {
        
        //when clicked
        if(Input.GetMouseButtonDown(0)){
            startPosition = Input.mousePosition;
            selectionBox = new Rect();
        }
        
        //when draggin 
        if(Input.GetMouseButton(0)){
            endPosition = Input.mousePosition;
            DrawVisual();
            DrawSelection();
        }

        //when release clicked
        if(Input.GetMouseButtonUp(0)){
            SelectUnits();
            startPosition = Vector2.zero;
            endPosition = Vector2.zero;
            DrawVisual();
        }
    }

    void DrawVisual(){
        Vector2 boxStart = startPosition;
        Vector2 boxEnd = endPosition;

        Vector2 boxCenter = (boxStart + boxEnd) / 2;
        boxVisual.position = boxCenter;

        Vector2 boxSize = new Vector2(Mathf.Abs(boxStart.x - boxEnd.x),Mathf.Abs(boxStart.y - boxEnd.y));

        boxVisual.sizeDelta = boxSize;
    }

    void DrawSelection(){
        // do x calculations
        if(Input.mousePosition.x < startPosition.x){
            //dragging left
            selectionBox.xMin = Input.mousePosition.x;
            selectionBox.xMax = startPosition.x;
        }else{
            //dragging right
            selectionBox.xMin = startPosition.x;
            selectionBox.xMax = Input.mousePosition.x;
        }

        //do y calculations
        if(Input.mousePosition.y < startPosition.y){
            //dragging down
            selectionBox.yMin = Input.mousePosition.y;
            selectionBox.yMax = startPosition.y;
        }else{
            //dragging up
            selectionBox.yMin = startPosition.y;
            selectionBox.yMax = Input.mousePosition.y;
        }
    } 

    void SelectUnits(){
        //loop through all the unit
        foreach(var unit in UnitSelecions.Instance.unitList){
            //if unit in box
            if(selectionBox.Contains(myCam.WorldToScreenPoint(unit.transform.position))){
                //if any unit is within the selection add them to selection
                UnitSelecions.Instance.DragSelect(unit);
            }
        }
    }
}