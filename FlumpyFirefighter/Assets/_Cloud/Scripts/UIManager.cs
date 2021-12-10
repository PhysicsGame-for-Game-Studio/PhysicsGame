using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager m_Instance;
    public TMP_Text fuelText;
    public TMP_Text fireText;
    public GameObject Fire_Pop;
    public GameObject Water_Pop;
    public GameObject fireIcon;

    private void Awake()
    {
        m_Instance = this;
    }
    private void Start()
    {
        UpdateUIData();
    }
    private void Update()
    {
        
    }
    public void UpdateUIData()
    {
        fuelText.text = GameManager.m_Instance.jetLeft.GetFuel().ToString();
        fireText.text = GameManager.m_Instance.firePutOut.ToString();
    }

    public void TriggerFirePopup()
    {
        Fire_Pop.GetComponent<Animator>().SetTrigger("pop");
    }

    public void TriggerWaterPopup()
    {
        Water_Pop.GetComponent<Animator>().SetTrigger("pop");
    }

    public void HighlightFire()
    {
        fireIcon.GetComponent<Animator>().SetTrigger("putting");
    }
}
