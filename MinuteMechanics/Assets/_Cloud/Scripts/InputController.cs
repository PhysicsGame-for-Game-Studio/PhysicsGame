using System;
using UnityEngine;
using UnityEngine.InputSystem;
// Set the rotation of the player from the input of DS4
public class InputController : MonoBehaviour
{
    public static InputController m_Instance;
    public Gamepad controller = null;
    private Transform m_transform;
    public float m_Sansitivity = 4000;
    public Camera m_MainCam;

    private void Awake()
    {
        m_Instance = this;
        this.controller = DS4.getConroller();
        m_transform = this.transform;
    }
    void Start()
    {

    }

    void Update()
    {
        if (controller == null)
        {
            try
            {
                controller = DS4.getConroller();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        else
        {
            // Press circle button to reset rotation
            if (controller.buttonEast.isPressed)
            {
                // to do
                m_transform.rotation = Quaternion.identity;



            }
            m_transform.rotation *= DS4.getXYZRotation(m_Sansitivity * Time.deltaTime);

            // Test button pressed
            if (Gamepad.current.aButton.wasPressedThisFrame)
            {
                Debug.Log("A button was pressed");
            }

            //if (Gamepad.current.rightStick)
            //{

            //}

        }
    }
    // unused
    // Rotates the camera around character's current position based on axis input.
    // PS4 - Right Analog Stick
    void updateCamRotation(Vector3 characterPosition)
    {

        // Set speed of rotation
        float rotationSpeed = 2;

        // Obtain Axes input.
        float rotateHorizontal = Input.GetAxis("RightStickX");
        float rotateVertical = Input.GetAxis("RightStickY");

        // Rotate camera about the character's current position.
        gameObject.transform.RotateAround(characterPosition, Vector3.up, rotateHorizontal * rotationSpeed);
        gameObject.transform.RotateAround(characterPosition, transform.right, rotateVertical * rotationSpeed);
    }
}