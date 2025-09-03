using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastExample : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Display", 3f);    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Display(){
        Debug.Log("DISPLAY");
    }
}
