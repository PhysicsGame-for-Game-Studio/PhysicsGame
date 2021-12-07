using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapController : MonoBehaviour
{
    public GameObject target;
    public Vector3 cameraOffset;
    bool doRotate = false;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        this.transform.position = target.transform.position + cameraOffset;

        //this.transform.eulerAngles = new Vector3(90, 0, -target.transform.eulerAngles.y);

    }
}
