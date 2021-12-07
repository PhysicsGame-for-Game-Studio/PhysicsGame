using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class FuelBar : MonoBehaviour
{

    public TMP_Text fuelText;
    public Image fuelBar;
    public Image[] fuelPoints;
    public bool[] PointsShow;

    [SerializeField]
    float curFuel, maxFuel;
    [SerializeField]
    private float lerpSpeed;

    private void Start()
    {
        curFuel = maxFuel = GameManager.m_Instance.maxFuel;

    }

    private void Update()
    {
        curFuel = GameManager.m_Instance.curFuel;
        fuelText.text = curFuel.ToString();

        lerpSpeed = 3f * Time.deltaTime;

        FuelBarFiller();
        ColorChanger();
    }

    void FuelBarFiller()
    {
        fuelBar.fillAmount = Mathf.Lerp(fuelBar.fillAmount, curFuel / maxFuel, lerpSpeed);

        for(int i = 0; i < fuelPoints.Length; i++)
        {
            Debug.Log(!DisplayFuelPoint(curFuel, i)+" No. "+i);
            fuelPoints[i].enabled = !DisplayFuelPoint(curFuel, i);
            PointsShow[i] = !DisplayFuelPoint(curFuel, i);
        }
    }

    void ColorChanger()
    {

    }

    bool DisplayFuelPoint(float _fuel, int pointNum)
    {
        return ((pointNum * 10) >= _fuel);
    }

}
