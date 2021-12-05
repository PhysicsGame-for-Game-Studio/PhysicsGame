using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class FuelBar : MonoBehaviour
{

    public TMP_Text fuelText;
    public Image fuelBar;

    float curFuel, maxFuel;

    private void Start()
    {
        curFuel = maxFuel = GameManager.m_Instance.maxFuel;

    }

    private void Update()
    {
        curFuel = GameManager.m_Instance.curFuel;
        fuelText.text = curFuel.ToString();
        FuelBarFiller();
    }

    void FuelBarFiller()
    {
        fuelBar.fillAmount = curFuel / maxFuel;
    }

}
