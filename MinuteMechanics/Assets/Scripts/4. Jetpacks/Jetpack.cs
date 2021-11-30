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

    public float maxFuel = 4f;
    public float thrustForce = 0.5f;
    public Rigidbody rigid; // player rigid
    public Transform groundedTransform;
    public ParticleSystem effect;

    private bool isGrounded = false;


    private float curFuel;
    public SideRL side;

    // Start is called before the first frame update
    void Start()
    {
        curFuel = maxFuel;
        this.controller = InputController.m_Instance.controller;
        m_transform = this.transform;
    }

    // Update is called once per frame
    void Update()
    {

        var gamepad = Gamepad.current;
        if (gamepad == null)
            return; // No gamepad connected.

        rigid.freezeRotation = true;

        thrustForce = 2.0f + ((10.0f - curFuel) * 0.9f);

        if (side == SideRL.Right && gamepad.rightTrigger.wasPressedThisFrame)
        {
            // 'Use' code here
            curFuel -= Time.deltaTime;
            rigid.AddForce(rigid.transform.up * thrustForce, ForceMode.Impulse);
            effect.Play();

        }
        else if (side == SideRL.Left && gamepad.leftTrigger.wasPressedThisFrame)
        {
            // 'Use' code here
            curFuel -= Time.deltaTime;
            rigid.AddForce(rigid.transform.up * thrustForce, ForceMode.Impulse);
            effect.Play();
        }
        else if (Physics.Raycast(groundedTransform.position, Vector3.down, 0.05f, LayerMask.GetMask("Grounded")) && curFuel < maxFuel)
        {
            curFuel += Time.deltaTime;
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
