using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myplayer : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            this.transform.Translate(Vector3.forward * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            this.transform.Translate(Vector3.back * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            this.transform.Translate(Vector3.left * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            this.transform.Translate(Vector3.right * Time.deltaTime);
        }
    }


    private void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.name == "Ball")
        {
            c.gameObject.GetComponent<MeshRenderer>().material.color = new Color(0, 0, 0);
        }
    }

    private void OnCollisionExit(Collision c)
    {
        if (c.gameObject.name == "Ball")
        {
            c.gameObject.GetComponent<MeshRenderer>().material.color = Color.white;
        }
    }


}
