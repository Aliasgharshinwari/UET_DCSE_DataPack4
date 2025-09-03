using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour{
    public float speed = 1f;

    // Update is called once per frame
    void Update(){
        if (Input.GetKey(KeyCode.W))
            transform.Translate(Vector3.forward * Time.deltaTime * speed);

        if (Input.GetKey(KeyCode.S))
            transform.Translate(Vector3.back * Time.deltaTime * speed);
        
        if (Input.GetKey(KeyCode.A))
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        
        if (Input.GetKey(KeyCode.D))
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        
        if (Input.GetKey(KeyCode.Q))
            transform.Rotate(Vector3.up * Time.deltaTime * speed * 100f);  // Multiply speed by 100 to achieve noticeable rotation
        
        if (Input.GetKey(KeyCode.E))
            transform.Rotate(Vector3.down * Time.deltaTime * speed * 100f);  
    }

    void LateUpdate(){
        if (transform.rotation.x != 0 || transform.rotation.z != 0)
            SetPosRot();
        
    }

    void OnCollisionEnter(Collision col){
        if (col.gameObject.CompareTag("ball"))
            col.gameObject.GetComponent<MeshRenderer>().material.color = Color.yellow;
        
    }
    void OnCollisionExit(Collision col){
        if (col.gameObject.CompareTag("ball"))
            col.gameObject.GetComponent<MeshRenderer>().material.color = Color.white;
        
    }

    public void SetPosRot(){
        // Preserve the y-axis rotation, reset x and z rotation
        float yRotation = transform.rotation.eulerAngles.y;
        Quaternion newRotation = Quaternion.Euler(0f, yRotation, 0f);

        // Apply position and rotation
        transform.SetPositionAndRotation(transform.position, newRotation);

    }
}
