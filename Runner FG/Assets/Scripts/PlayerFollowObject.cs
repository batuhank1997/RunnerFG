using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollowObject : MonoBehaviour
{
    public float speed;
    private Vector3 touchPos;
    private Touch touch;
    private Rigidbody rb;
    private Vector3 mousePos;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR

        if (Input.GetMouseButtonDown(0))
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 direction = transform.position - mousePos;
            transform.position = new Vector3(transform.position.x + direction.x * speed, transform.position.y, transform.position.z);
        }
#endif
    }
    private void FixedUpdate()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                if(transform.position.x < -9)
                    rb.MovePosition(new Vector3(-8.5f, transform.position.y, transform.position.z));
                if (transform.position.x > 9)
                    rb.MovePosition(new Vector3(8.5f, transform.position.y, transform.position.z));

                rb.MovePosition(new Vector3(transform.position.x + touch.deltaPosition.x * speed * Time.deltaTime, transform.position.y, transform.position.z));
            }
        }
    }
}
