using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField]
    private float maxGunmountAngle,minGunmountAngle = 5f; //altitude
    [SerializeField]
    private float rotateSpeed = 2f;
    [SerializeField]
    
    private Transform bulletSpawnPoint;
    [SerializeField]
    private Transform turret;
    [SerializeField]
    private Transform gunmount;
    private Transform GunOriginRotate;

    private void Update() {
        if(Input.GetKey("r")){
            Rotate();
        }
    }

    private void Rotate(){
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit)) {
            Vector3 targetDir = hit.point - turret.position;
            targetDir.y = 0f;
            targetDir = targetDir.normalized;

            Vector3 currentDir = turret.forward;
            currentDir = Vector3.RotateTowards(currentDir,targetDir,rotateSpeed*Time.deltaTime,1f);

            Quaternion qDir = new Quaternion();
            qDir.SetLookRotation(currentDir,Vector3.up);
            turret.rotation = qDir;
        }
    }

}