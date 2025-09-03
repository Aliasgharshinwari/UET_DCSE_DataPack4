using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletlogic : MonoBehaviour
{
    private void Start()
    {
        Invoke("DestroyYourSelf", 2f);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Ball")
        {
            Destroy(collision.gameObject);
        }
    }

    void DestroyYourSelf()
    {
        Destroy(this.gameObject);
    }
}
