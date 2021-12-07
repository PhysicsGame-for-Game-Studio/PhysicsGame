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
        
    }

    private void Update()
    {
        this.transform.position = target.transform.position + cameraOffset;


        float rot_x, rot_y, rot_z;
        rot_x = this.transform.rotation.eulerAngles.x;
        rot_y = target.transform.rotation.eulerAngles.y;
        rot_z = this.transform.rotation.eulerAngles.z;
        this.transform.rotation = Quaternion.Euler(90, -rot_y, rot_z);
        //this.transform.eulerAngles = new Vector3(90, 0, -target.transform.eulerAngles.y);

    }
}
