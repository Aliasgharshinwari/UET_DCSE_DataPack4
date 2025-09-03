using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelegateExample : MonoBehaviour
{
    public delegate void One();

    One oneDel;

    // Start is called before the first frame update
    void Start()
    {
     oneDel = SomeMethod1;   
     oneDel += SomeMethod2;  
     oneDel(); 
     //oneDel -= SomeMethod1;  
     //oneDel("Message"); 

    }

    void SomeMethod1(){
        Debug.Log("Message" + "1");
    }
    void SomeMethod2(){
          Debug.Log("Message" + "2");
    }
}
