using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newtransform : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.transform.Rotate(new Vector3(1, 1, 1));
        //this.transform.localScale = new Vector3(5, 5, 5);
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.z > 200)
        {
            this.transform.Rotate(new Vector3(1, 1, 1));
            this.transform.Translate(Vector3.forward * Time.deltaTime);
            //this.transform.localScale = new Vector3(this.transform.localScale.x + 1, this.transform.localScale.y + 1, this.transform.localScale.z + 1);
        }
    }
}
