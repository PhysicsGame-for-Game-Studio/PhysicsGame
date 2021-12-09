using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public GameObject target;
    private void Update()
    {
        float x, y, z;
        x = target.transform.position.x;
        z = target.transform.position.z;
        y = Mathf.Max(target.transform.position.y, 30f);
        transform.position = new Vector3(x, y, z);
    }
}
