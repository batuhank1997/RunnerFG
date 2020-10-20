using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineScript : MonoBehaviour
{
    public Rigidbody rb;
    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        speed = 40;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector3(0, 0, -speed);
    }
}
