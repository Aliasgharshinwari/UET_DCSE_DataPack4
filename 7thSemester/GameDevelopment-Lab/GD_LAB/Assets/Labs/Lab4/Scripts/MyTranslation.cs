using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyTranslation : MonoBehaviour{
    public float maxDistance;
    private Vector3 initialPos;
    private bool isMovingForward = true;

    // Start is called before the first frame update
    void Start(){
        initialPos = transform.position;
        Debug.Log("World");
    }

    // Update is called once per frame
    void Update(){
        var dir = transform.position - initialPos;
        var dist = dir.magnitude;
        //Debug.Log(dir.magnitude);
        if (isMovingForward){
            transform.Translate(Vector3.forward * Time.deltaTime);             
        }

        else{
            transform.Translate(-Vector3.forward * Time.deltaTime);             
            
        }
        
        if (dist > maxDistance){
            isMovingForward = false;
        }

        else if((int)dist == 0f){
            isMovingForward = true;
        }
    }
}
