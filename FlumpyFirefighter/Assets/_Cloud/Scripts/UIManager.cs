using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager m_Instance;
    public TMP_Text fuelText;
    public TMP_Text fireText;
    private void Awake()
    {
        m_Instance = this;
    }
    private void Start()
    {
        UpdateData();
    }
    private void Update()
    {
        
    }
    public void UpdateData()
    {
        fuelText.text = GameManager.m_Instance.jetLeft.GetFuel().ToString();
        fireText.text = GameManager.m_Instance.firePutOut.ToString();
    }
}
