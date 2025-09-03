using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyScale : MonoBehaviour{
    public Vector3 maxScale;
    private bool isIncreasing = true;

    // Start is called before the first frame update
    void Start(){
        Debug.Log("!");
    }

    // Update is called once per frame
    void Update(){

        if (isIncreasing)
            transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
        else
            transform.localScale += new Vector3(-0.1f, -0.1f, -0.1f);

        if (transform.localScale.x > maxScale.x && 
            transform.localScale.y > maxScale.y && 
            transform.localScale.z > maxScale.z){

            isIncreasing = false;
        }

        else if (transform.localScale.x < 1 && 
                transform.localScale.y < 1 && 
                transform.localScale.z < 1){
            isIncreasing = true;
        }
    }
}
