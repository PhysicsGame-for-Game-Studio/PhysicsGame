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

    [Header("Water")]
    public int totalWater;
    public int pWater;
    public Transform waterParent;

    [Header("Center")]
    public Transform center;
    BoxCollider m_Collider;
    float m_ScaleX, m_ScaleY, m_ScaleZ;

    Vector3 size;

    private void Awake()
    {
        m_Instance = this;
    }
    void Start()
    {
        m_Collider = center.gameObject.GetComponent<BoxCollider>();
        m_ScaleX = m_Collider.size.x;
        m_ScaleY = m_Collider.size.y;
        m_ScaleZ = m_Collider.size.z;
        size = new Vector3(m_ScaleX, m_ScaleY, m_ScaleZ);
        SpawnItems(fire, fireParent, totalFire, pFire);
        SpawnItems(water, waterParent, totalWater, pWater);
    }


    public void SpawnItems(GameObject obj, Transform parent, int total, float possibility)
    {
        for(int i=0; i < total; i++)
        {
            float seed = Random.Range(0, 1f);
            if (seed < possibility)
            {
                SpawnItem(obj, parent);
            }
           
        }
    }

    public void SpawnItem(GameObject obj, Transform parent)
    {
        Vector3 pos = center.position + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));

        GameObject item = Instantiate(fire, pos, Quaternion.identity);
        item.transform.parent = parent.transform;
    }
}
