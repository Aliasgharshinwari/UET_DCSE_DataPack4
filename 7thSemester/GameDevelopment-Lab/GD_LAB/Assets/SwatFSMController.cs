using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwatFSMController : MonoBehaviour
{
    Animator anim;
    public float accel = 0.1f;
    public float deccel = 0.5f;
    public float currentSpeed = 0;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();    
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W) ){
            if(Input.GetKey(KeyCode.LeftShift))
                currentSpeed += Time.deltaTime*accel*10;
            else
                currentSpeed += Time.deltaTime*accel;
    
            anim.SetBool("isWalking", true);
            anim.SetFloat("speed", currentSpeed);
        }

        else{
            currentSpeed -= Time.deltaTime*deccel;
            anim.SetBool("isWalking", false);
            anim.SetFloat("speed", currentSpeed);
        }

        if (currentSpeed < 0)
        {
            currentSpeed = 0;
        }
        
    }
}
