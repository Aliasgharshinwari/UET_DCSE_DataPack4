using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lab7{
    
public class CameraFollow : MonoBehaviour{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offsetPos;

    // Update is called once per frame
    void LateUpdate(){
        transform.SetPositionAndRotation(target.position + offsetPos, 
                                            transform.rotation);
        transform.LookAt(target);
    }
}

}