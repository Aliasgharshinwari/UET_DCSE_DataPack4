using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myscript5 : MonoBehaviour
{
    public float speed = 5f;
    bool flag = true;

    public GameObject x;

    // Start is called before the first frame update
    void Start()
    {
        x = GameObject.FindGameObjectWithTag("customtag");
    }

    // Update is called once per frame
    void Update()
    {
        x.transform.Rotate(new Vector3(0, 1, 0));
    }
}
