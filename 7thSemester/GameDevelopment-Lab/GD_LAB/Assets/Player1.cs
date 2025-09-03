using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    public float speed = 1f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }

    }


    void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.CompareTag("ball"))
        {
            col.gameObject.GetComponent<MeshRenderer>().material.color = Color.yellow;
            Debug.Log("OnCollisionEnter");
        }

    }
    void OnCollisionExit(Collision col)
    {

        if (col.gameObject.CompareTag("ball"))
        {
            col.gameObject.GetComponent<MeshRenderer>().material.color = Color.white;
            Debug.Log("OnCollisionExit");
        }

    }



}
