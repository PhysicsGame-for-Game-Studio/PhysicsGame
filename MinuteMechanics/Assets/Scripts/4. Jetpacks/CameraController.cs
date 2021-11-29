using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// no use 
// use cinemachine instead
public class CameraController : MonoBehaviour
{
    public bool Lookat;

    [SerializeField]
    Transform followTarget;
    [SerializeField]
    Vector3 followOffset;
    [SerializeField]
    Transform lookAtTarget;
    [SerializeField]
    Vector3 lookAtOffset;
    [SerializeField]
    float followSpeed;

    void Start()
    {

    }

    void FixedUpdate()
    {
        if (followTarget != null)
        {
            var desiredPosition = followTarget.position + followOffset;
            var smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, followSpeed * Time.fixedDeltaTime);
            transform.position = smoothedPosition;
        }

        if (Lookat==true && lookAtTarget != null)
            transform.LookAt(lookAtTarget.position + lookAtOffset);

    }
}

