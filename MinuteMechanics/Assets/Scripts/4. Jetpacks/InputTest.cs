using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputTest : MonoBehaviour
{
    public static InputTest m_Instance;
    public Gamepad controller = null;
    private Transform m_transform;
    public float m_Sansitivity = 4000;

    private void Awake()
    {
        m_Instance = this;
    }
    void Start()
    {
        this.controller = DS4.getConroller();
        m_transform = this.transform;
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
                m_transform.rotation = Quaternion.identity;
            }
            m_transform.rotation *= DS4.getRotation(m_Sansitivity * Time.deltaTime);
        }
    }
}