using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playersix : MonoBehaviour
{
    RaycastHit hit;
    public GameObject BulletPrefab;
    GameObject LiveObject; //this is loaded bullet in scene

    private void Start()
    {
        InvokeRepeating("Test", 1f, 5f);
    }

    private void Update()
    {

        if (Physics.Raycast(this.transform.position, Vector3.forward, out hit, Mathf.Infinity))
        {
            Debug.Log("Object Hit: " + hit.collider.name);
            Debug.DrawRay(transform.position, Vector3.forward * hit.distance, Color.red);

            if (hit.collider.name == "Ball")
            {


            }

        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            LiveObject = Instantiate(BulletPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.6f), transform.rotation) as GameObject;
            LiveObject.GetComponent<Rigidbody>().AddForce(Vector3.forward * 20f, ForceMode.Impulse);
        }


    }

    void Test()
    {
        int x = Random.Range(0, 100);
        print("Number: " + x);
    }

}
