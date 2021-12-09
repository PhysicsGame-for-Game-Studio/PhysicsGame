using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceGenerator : MonoBehaviour
{
    public static ResourceGenerator m_Instance;
    public GameObject fire;
    public GameObject water;

    [Header("Fire")]
    public int totalFire;
    public int pFire;
    public Transform fireParent;
    public int currentFire;

    [Header("Water")]
    public int totalWater;
    public int pWater;
    public Transform waterParent;
    public int currentWater;

    [Header("Center")]
    public Transform fireCenter;
    public Transform waterCenter;

    public GameObject m_FireSpace;
    public GameObject m_WaterSpace;
    float m_ScaleX, m_ScaleY, m_ScaleZ;


    public Vector3[] size;

    private void Awake()
    {
        m_Instance = this;
    }
    void Start()
    {
        size = new Vector3[2];
        // fire
        m_ScaleX = m_FireSpace.transform.localScale.x;
        m_ScaleY = m_FireSpace.transform.localScale.y;
        m_ScaleZ = m_FireSpace.transform.localScale.z;
        size[0] = new Vector3(m_ScaleX, m_ScaleY, m_ScaleZ);
        SpawnItems(fire, fireParent, fireCenter, size[0], totalFire, pFire);
        currentFire = totalFire;
        // water
        m_ScaleX = m_WaterSpace.transform.localScale.x;
        m_ScaleY = m_WaterSpace.transform.localScale.y;
        m_ScaleZ = m_WaterSpace.transform.localScale.z;
        size[1] = new Vector3(m_ScaleX, m_ScaleY, m_ScaleZ);
        SpawnItems(water, waterParent, waterCenter, size[1], totalWater, pWater);
        SpawnWater(15);
        currentWater = totalWater;
    }

    public void SpawnFire(int num)
    {
        SpawnItems(fire, fireParent, fireCenter, size[0], num, pFire);
    }

    public void SpawnWater(int num)
    {
        SpawnItems(water, waterParent, waterCenter, size[1], num, pWater);
    }

    private void Update()
    {
        if (currentFire < totalWater - 5)
        {
            SpawnFire(1);
        }

        if (currentWater < totalWater - 5)
        {
            SpawnWater(2);
        }
    }

    public void SpawnItems(GameObject obj, Transform parent, Transform center, Vector3 size, int total, float possibility)
    {
        for(int i=0; i < total; i++)
        {
            float seed = Random.Range(0, 10f);
            if (seed < possibility)
            {
                SpawnItem(obj, parent, center, size);
            }
           
        }
    }

    public void SpawnItem(GameObject obj, Transform parent, Transform center, Vector3 size)
    {
        Vector3 pos = center.position + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));

        GameObject item = Instantiate(obj, pos, Quaternion.identity);
        item.transform.parent = parent.transform;
    }
}
