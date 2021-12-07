using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour
{
    public float speed;
    Rigidbody myRg;
    // Start is called before the first frame update
    void Start()
    {
        myRg = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButton("MoveHorizontally"))
        {
            myRg.AddForce(Vector3.right * Input.GetAxis("MoveHorizontally") * speed);
        }
        if (Input.GetButton("MoveVertically"))
        {
            myRg.AddForce(Vector3.forward * Input.GetAxis("MoveVertically") * speed);
        }

    }
}
