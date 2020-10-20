using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeverScript : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim.Play("FeverAnim");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
