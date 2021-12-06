using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterController : MonoBehaviour
{
    public Transform groundLevel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < groundLevel.position.y)
        {
            Destroy(gameObject);
        }
    }
    void Absorbed()
    {
        transform.position -= new Vector3(0, .01f, 0);
    }
}
