using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBallControll : MonoBehaviour
{
    public static WaterBallControll m_Instance;
    [SerializeField] bool _update;
    [SerializeField] Transform _CreationPoint;
    [SerializeField] WaterBall WaterBallPrefab;
    WaterBall waterBall;
    GameObject particle;

    public Transform player;
    public float distance = 10f;
    private void Awake()
    {
        m_Instance = this;
    }
    private void Update()
    {
        if (!_update)
        {
            return;
        }

        
    }
    public bool WaterBallCreated()
    {
        return waterBall != null;
    }
    public void CreateWaterBall()
    {
        waterBall = Instantiate(WaterBallPrefab, _CreationPoint.position, Quaternion.identity);
    }


}
