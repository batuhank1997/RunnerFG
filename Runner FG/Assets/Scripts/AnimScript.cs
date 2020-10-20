using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        //Play jump animation
        if (other.tag == "JumpPoint")
        {
            anim.SetTrigger("Jump");
        }
    }
    
}
