using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewEnemyScript : MonoBehaviour
{
    private Vector3 velocity;
    public Transform target;
    public Rigidbody rb;
    [SerializeField]
    private float speed;
    private bool checkJump = true;
    private bool checkRegion = false;
    public Animator anim;
    public Animator cameraShakeAnim;
    private Vector3 direction = Vector3.forward;

    bool check = false;

    private void Start()
    {
        speed = GameController.I.generalSpeed;
        if(GameController.I.CurrentPlayer != null)
            target = GameController.I.CurrentPlayer.transform;
        rb = GetComponent<Rigidbody>();
        
        velocity = Vector3.zero;
    }
    private void Update()
    {
        rb.velocity = direction * -speed;
        
        if (checkRegion)
        {
            if (checkJump)
            {
                if (GameController.I.CurrentPlayer == null)
                    return;
                else
                {
                    transform.rotation = Quaternion.LookRotation(transform.position - GameController.I.CurrentPlayer.transform.position, Vector3.up);
                    Vector3 desiredPosition = new Vector3(GameController.I.CurrentPlayer.transform.position.x, transform.position.y, transform.position.z);
                    transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, 0.6f, Mathf.Infinity, Time.deltaTime);
                }
            }
        }
        if (check)
        {
            transform.position += Vector3.up * 60 * Time.deltaTime;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "JumpPoint")
        {
            if (target != null)
            {
                //speed = 50;
                direction = -(target.position - transform.position).normalized;
                checkJump = false;
                transform.rotation = Quaternion.LookRotation(direction, Vector3.up);
            }
        }
        if (other.gameObject.tag == "Region")
        {
            checkRegion = true;
        }
        if (other.gameObject.tag == "Player")
        {
            if(GameController.I.feverMode == false)
            {
                GameController.III.gameOver = true;
                Destroy(other.gameObject);
            }
            else if(GameController.I.feverMode == true)
            {
                Debug.Log("Fever Hit");
                check = true;
            }
        }
    }
}
