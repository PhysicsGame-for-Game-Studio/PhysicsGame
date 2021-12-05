using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager m_Instance;

    public Jetpack jetLeft;
    public Jetpack jetRight;
    public float maxFuel = 4f;
    public float curFuel;

    public float gravity = -9.81f;

    public float gpmConsume, gpmRefill;
    public float gpmConsumeBoost, gpmRefillBoost;

    private void Awake()
    {
        m_Instance = this;
    }
    private void Start()
    {
        curFuel = maxFuel;
    }

    public void ComputeFuel(FuelMode mode)
    {
        switch (mode)
        {
            case FuelMode.defaultJet:
                ConsumingFuel(gpmConsume);
                break;
            case FuelMode.defaultRefill:
                RefillFuel(gpmRefill);
                break;
            case FuelMode.boostJet:
                ConsumingFuel(gpmConsumeBoost);
                break;
            case FuelMode.boostRefill:
                RefillFuel(gpmRefillBoost);
                break;
        }

        if (curFuel > maxFuel) curFuel = maxFuel;
        if (curFuel < 0) curFuel = 0;

    }
     
    public void ConsumingFuel(float amount)
    {
        if (curFuel > 0)
        {
            curFuel -= amount;
        }

    }

    public void RefillFuel(float amount)
    {
        if (curFuel < maxFuel)
        {
            curFuel += amount;
        }
    }
}
