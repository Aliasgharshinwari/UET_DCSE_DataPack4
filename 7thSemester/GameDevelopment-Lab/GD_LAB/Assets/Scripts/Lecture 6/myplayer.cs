using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myplayer6 : MonoBehaviour
{


    void Update()
    {
        /*if (Input.GetKey(KeyCode.W))
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
        }*/


        float horz = Input.GetAxis("Horizontal") * Time.deltaTime;
        float vert = Input.GetAxis("Vertical") * Time.deltaTime;

        this.transform.Translate(new Vector3(horz, 0, vert));



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
