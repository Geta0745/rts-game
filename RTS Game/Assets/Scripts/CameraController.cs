using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private float normalSpeed = .5f;
    [SerializeField]
    private float fastSpeed = 3f;
    [SerializeField]
    private float panSpeed;
    [SerializeField]
    private float panBorderThickness = 10f;

    [SerializeField]
    private Vector2 panLimit;
    [SerializeField]
    private float minY,maxY;
    [SerializeField]
    private float scrollSpeed = 2f;
    private void Update() {
        HandleInput();
    }

    void HandleInput(){
        if(Input.GetKey(KeyCode.LeftShift)){
            panSpeed = fastSpeed;
        }else{
            panSpeed = normalSpeed;
        }

        Vector3 pos = transform.position;

        if(Input.mousePosition.y >= Screen.height - panBorderThickness){//upward
            pos.z += panSpeed * Time.deltaTime;
        }
        if(Input.mousePosition.y <= panBorderThickness){//down
            pos.z -= panSpeed * Time.deltaTime;
        }
        if(Input.mousePosition.x >= Screen.width - panBorderThickness){//right
            pos.x += panSpeed * Time.deltaTime;
        }
        if(Input.mousePosition.x <= panBorderThickness){
            pos.x -= panSpeed * Time.deltaTime;
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        pos.y -= scroll * scrollSpeed * Time.deltaTime;
        pos.x = Mathf.Clamp(pos.x,-panLimit.x,panLimit.x);
        pos.y = Mathf.Clamp(pos.y,minY,maxY);
        pos.z = Mathf.Clamp(pos.z,-panLimit.y,panLimit.y);

        transform.position = pos;
    }
}
