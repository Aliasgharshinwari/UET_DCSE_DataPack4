using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offsetPos;

    // Update is called once per frame
    void LateUpdate(){
        transform.LookAt(target);
        transform.position = target.position + offsetPos;
        //transform.SetPositionAndRotation(target.position + offsetPos, 
        //                                    transform.rotation);
    }
}
