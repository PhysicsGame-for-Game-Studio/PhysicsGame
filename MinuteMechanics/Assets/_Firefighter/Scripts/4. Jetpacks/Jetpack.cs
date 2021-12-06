using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public enum SideRL
{
    Right=0,
    Left,
}

public class Jetpack : MonoBehaviour
{
    private Gamepad controller = null;
    private Transform m_transform;


    public float thrustForce = 0.5f;
    public Rigidbody rigid; // player rigid
    public Transform groundedTransform;
    public ParticleSystem effect;
    public ParticleSystem effectBoost;

    private bool isGrounded = false;
    Vector3 m_NewForce;

    private float curFuel;
    private float maxFuel;
    public SideRL side;
    private bool isBoost;   // 加速模式

    // Start is called before the first frame update
    void Start()
    {
        curFuel = maxFuel = GameManager.m_Instance.maxFuel;
       
        this.controller = InputController.m_Instance.controller;
        m_transform = this.transform;
        m_NewForce = new Vector3(-5.0f, 1.0f, 0.0f);

        isBoost = false;
    }

    public void PlayEffect(bool boostMode = false)
    {
        if (boostMode)
        {
            effectBoost.Play();
        }
        else
        {
            effect.Play();
        }
    }

    public void StopEffect()
    {
        effectBoost.Stop();
        effect.Stop();
        Debug.Log("effect stop.");
    }

    // Update is called once per frame
    void Update()
    {

        var gamepad = Gamepad.current;
        if (gamepad == null)
            return; // No gamepad connected.

        rigid.freezeRotation = true;

        if (gamepad.rightTrigger.wasPressedThisFrame)
        {
            // 'Use' code here
            GameManager.m_Instance.ComputeFuel(FuelMode.defaultJet);
            rigid.AddForce(transform.up * thrustForce, ForceMode.Impulse);

            isBoost = false;
            PlayEffect(isBoost);
             Debug.Log("UP: " + transform.up);
        }
        else if (gamepad.leftTrigger.wasPressedThisFrame)
        {
            // 'Use' code here
            GameManager.m_Instance.ComputeFuel(FuelMode.defaultJet);

            rigid.AddForce(transform.up * thrustForce, ForceMode.Impulse);

            isBoost = true;
            PlayEffect(isBoost);

        }
        else if (Physics.Raycast(groundedTransform.position, Vector3.down, 0.05f, LayerMask.GetMask("Grounded")) && curFuel < maxFuel)
        {
            GameManager.m_Instance.ComputeFuel(FuelMode.defaultRefill);
            isBoost = false;
            effect.Stop();
        }
        else
        {
            effect.Stop();
        }

        //Vector2 move = gamepad.leftStick.ReadValue();
        //'Move' code here
    }

    public float GetFuel()
    {
        return curFuel;
    }


}
public static class TransformExtensions
{
    public static void SetYPos(this Transform t, float newYPos)
    {
        var pos = t.position;
        pos.y = newYPos;
        t.position = pos;
    }
}
