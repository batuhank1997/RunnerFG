using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float smoothTime = 0;
    public Vector3 offset;


    private void Start()
    {
        offset = new Vector3(-0, 10f, -20f);
    }
    void LateUpdate()
    {
        if (target == null)
            return;
        else
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, 1);
            transform.position = smoothedPosition;
        }
    }

}
