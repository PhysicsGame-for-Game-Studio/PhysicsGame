using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : MonoBehaviour
{
    ParticleSystem fire;
    GameObject fireHolder;
    //float rate = 10;
    float size = 1;
    // Start is called before the first frame update
    void Start()
    {
        fire = transform.GetChild(0).GetComponent<ParticleSystem>();
        fireHolder = transform.GetChild(0).gameObject;
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (rate <= 0)
        //{
        //    rate = 0;
        //}
        //if (rate == 0)
        //{
        //    Destroy(fire.gameObject);
        //}
        if (fireHolder)
        {
            fireHolder.transform.localScale = new Vector3(size, size, size);
        }

        if (size <= 0)
        {
            size = 0;
        }
        if (size == 0)
        {
            Destroy(fireHolder);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        //Debug.Log("entered");
        if (other.CompareTag("Rain") && size > 0)
        {
            //var em = fire.emission;
            //rate -= .1f;
            //em.rateOverTime = rate;
            //Debug.Log(em.rateOverTime);
            //fire.emission = em;

            size -= 0.01f;
        }
    }
}
