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


    public float thrustForce;
    public float boostForce;
    public Rigidbody rigid; // player rigid
    public Transform groundedTransform;
    public ParticleSystem[] effect;
    public ParticleSystem[] effectBoost;
    public ParticleSystem waterDrop;

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
        waterDrop.Play();
        if (boostMode)
        {
            
            for (int i=0;i< effectBoost.Length;i++)
                effectBoost[i].Play();
        }
        else
        {
            for (int i = 0; i < effect.Length; i++)
                effect[i].Play();
        }
    }

    public void StopEffect()
    {
        waterDrop.Stop();
        for (int i = 0; i < effectBoost.Length; i++)
            effectBoost[i].Stop();
        for (int i = 0; i < effect.Length; i++)
            effect[i].Stop();
        //Debug.Log("effect stop.");
    }

    // Update is called once per frame
    void Update()
    {

        var gamepad = Gamepad.current;
        if (gamepad == null)
            return; // No gamepad connected.

        rigid.freezeRotation = true;

        if (gamepad.rightShoulder.wasPressedThisFrame)
        {
            // 'Use' code here
            GameManager.m_Instance.ComputeFuel(FuelMode.defaultJet);
            rigid.AddForce(transform.up * thrustForce, ForceMode.Impulse);

            isBoost = false;
            PlayEffect(isBoost);
            Debug.Log("UP: " + transform.up);
        }
        else if (gamepad.rightTrigger.wasPressedThisFrame)
        {
            // 'Use' code here
            GameManager.m_Instance.ComputeFuel(FuelMode.defaultJet);

            rigid.AddForce(transform.up * boostForce, ForceMode.Impulse);

            isBoost = true;
            PlayEffect(isBoost);

        }
        else if (Physics.Raycast(groundedTransform.position, Vector3.down, 0.05f, LayerMask.GetMask("Grounded")) && curFuel < maxFuel)
        {
            GameManager.m_Instance.ComputeFuel(FuelMode.defaultRefill);
            isBoost = false;
            StopEffect();
        }
        else
        {
            StopEffect();
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
