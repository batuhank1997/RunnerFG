using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public GameObject target;
    public float smoothVariable;
    public float speed;
    public float waitSec;
    private bool checkJump = true;

    private CharacterController controller;
    private Vector3 direction;

    public int defaultLane = 0;
    public float distanceBetweenLanes = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        //controller.isTrigger = true;
    }

    private void Update()
    {
        controller.Move(direction * Time.deltaTime);
        direction.z = -speed;
        if (checkJump)
        {
            Movement();
        }
    }
   
    void Movement()
    {
        //movement inputs
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (defaultLane == 0)
            {
                defaultLane++;
            }
            else
            {
                return;
            }
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (defaultLane == 1)
            {
                defaultLane--;
            }
            else
            {
                return;
            }
        }
        
        StartCoroutine(Delay());
    }
    
    IEnumerator Delay()
    {
        Debug.Log("debug");
        yield return new WaitForSeconds(waitSec);
        Debug.Log("debug 2");
        Vector3 desiredPosition = transform.position.z * transform.forward + transform.position.y * transform.up;
        
        if (defaultLane == 0)
        {
            desiredPosition += Vector3.left * distanceBetweenLanes;
        }
        else if (defaultLane == 1)
        {
            desiredPosition += Vector3.right * distanceBetweenLanes;
        }
        transform.position = Vector3.MoveTowards(transform.position, desiredPosition, smoothVariable * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "JumpPoint")
            checkJump = false;
    }

}
