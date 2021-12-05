using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TMP_Text fuelText;

    private void Update()
    {
        fuelText.text = GameManager.m_Instance.jetLeft.GetFuel().ToString();
    }

}
