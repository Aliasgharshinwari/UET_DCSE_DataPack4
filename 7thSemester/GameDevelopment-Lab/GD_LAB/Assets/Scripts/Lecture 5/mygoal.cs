using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mygoal : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ball"))
        {
            this.gameObject.GetComponent<MeshRenderer>().material.color = Color.green;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("ball"))
        {
            this.gameObject.GetComponent<MeshRenderer>().material.color = Color.white;
        }
    }
}
