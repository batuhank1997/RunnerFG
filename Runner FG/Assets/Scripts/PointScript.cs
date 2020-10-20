using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator anim;
    void Start()
    {
        if(gameObject.tag == "Point100")
        {
            anim.Play("Point");
        }
        else if (gameObject.tag == "Point500")
        {
            anim.Play("Point");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
