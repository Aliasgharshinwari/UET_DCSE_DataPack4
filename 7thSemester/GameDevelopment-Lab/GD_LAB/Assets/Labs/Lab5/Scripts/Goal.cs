using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour{

    void OnTriggerEnter(Collider other){
        if (other.gameObject.CompareTag("ball")){
            var rendrer = gameObject.GetComponent<MeshRenderer>();
            rendrer.material.color = Color.green;
        }        
    }

    void OnTriggerExit(Collider other){
        if (other.gameObject.CompareTag("ball")){
            var rendrer = gameObject.GetComponent<MeshRenderer>();
            rendrer.material.color = Color.white;
        }   
    }
}
