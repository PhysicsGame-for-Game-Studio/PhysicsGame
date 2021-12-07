using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbsorbController : MonoBehaviour
{
    public GameObject absorbParticle;
    //[Range(0,40)]
    float dist = 10.4f;

    bool instantiated = false;
    GameObject particle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        RaycastHit hit;
        //Debug.Log(LayerMask.GetMask("Water"));
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity, 16))
        {
            //Debug.Log(hit.transform.);
            hit.transform.SendMessage("Absorbed");
            if (!instantiated)
            {
                particle = Instantiate(absorbParticle, hit.point, Quaternion.Euler(90,0,0));
                
                instantiated = true;
            }
            else
            {
                particle.transform.position = hit.point;
            }
        }
        else
        {
            if (instantiated)
            {
                Destroy(particle);
                instantiated = false;
            }
        }
    }
}
