using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    PhysicsGameControls controls;
    public Rigidbody playerRB;
    public GameObject playerCamera;

    public Vector2 moveVal;
    public Vector2 rotVal;
    public float moveSpeed;

    private void Awake()
    {
        controls = new PhysicsGameControls();

        //controls.PlayerMovement.Pitch.performed += cntxt => moveVal = cntxt.ReadValue<Vector2>();
        //controls.PlayerMovement.Pitch.canceled += cntxt => moveVal = Vector2.zero;

        controls.PlayerMovement.CamRotate.performed += cntxt => rotVal = cntxt.ReadValue<Vector2>();
        controls.PlayerMovement.CamRotate.canceled += cntxt => rotVal = Vector2.zero;

    }

    void Start()
    {

    }

    void OnPitch(InputValue value)
    {
        moveVal = value.Get<Vector2>();
    }

    void OnCamRotate(InputValue value)
    {
        rotVal = value.Get<Vector2>();
    }


    void Update()
    {
        Vector3 m = new Vector3(moveVal.x * 5, 0, moveVal.y * 5);
        playerRB.velocity = m;

        //playerCamera.GetComponent<Transform>().Rotate(Vector3.up * rotVal.x * .2f);       // ·Ç Cinemachine

        transform.Translate(new Vector3(moveVal.x, moveVal.y, 0) * moveSpeed * Time.deltaTime);
    }
}
