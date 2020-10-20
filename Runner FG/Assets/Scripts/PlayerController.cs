using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float smoothVariable;
    public float screenWidth;
    public Animator feverAnim;
    public GameObject feverText;
    public Rigidbody rb;
    public GameObject target;
    private Vector3 direction = Vector3.forward;
    private Vector3 velocity;

    public float horizontalMove = 0f;
    public float speed;

    private void Awake()
    {
        if (gameObject == null)
            return;
        GameController.I.CurrentPlayer = gameObject;
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {

        transform.rotation = Quaternion.LookRotation(target.transform.position - transform.position, Vector3.up);
        Vector3 desiredPosition = new Vector3(target.transform.position.x, transform.position.y, transform.position.z);
        //transform.position = Vector3.Lerp(transform.position, desiredPosition, 0.2f);
        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, 0.1f, Mathf.Infinity, Time.deltaTime);

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Fever")
        {
            GameController.I.feverMode = true;
            feverText.SetActive(true);
            feverAnim.Play("FeverAnim");
        }
        if (other.gameObject.tag == "Gun")
        {
            GameController.I.gunMode = true;
            //feverText.SetActive(true);
        }
        if (GameController.I.feverMode == true)
        {
            if (other.gameObject.tag == "Enemy")
            {
                //cameraShake.CamShake();
            }
        }
    }
}
