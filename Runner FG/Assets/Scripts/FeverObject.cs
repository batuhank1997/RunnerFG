using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeverObject : MonoBehaviour
{
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(gameObject.tag == "Coin")
        {
            //rb.velocity = new Vector3(0, 0, -50);
            transform.Rotate(0, 3, 0);
        }
        else
        {
            rb.velocity = new Vector3(0, 0, -60);
            transform.Rotate(0, -3, 3);
        }
    }
}
