using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereScript : MonoBehaviour{
    private Color originalColor;
    void OnCollisionEnter(Collision col){

        if (col.gameObject.CompareTag("wall")){
            var rendrer = col.gameObject.GetComponent<MeshRenderer>();
            originalColor = rendrer.material.color;
            rendrer.material.color = Color.red;
            Debug.Log("OnCollisionEnter");
        }

    }
    void OnCollisionExit(Collision col){

        if (col.gameObject.CompareTag("wall")){
            var rendrer = col.gameObject.GetComponent<MeshRenderer>();
            rendrer.material.color = originalColor;
        }
    }
}
