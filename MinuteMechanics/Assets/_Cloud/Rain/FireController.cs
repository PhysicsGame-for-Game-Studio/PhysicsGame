using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : MonoBehaviour
{
    ParticleSystem fire;
    ParticleSystem smoke;
    //灭火后的烟
    ParticleSystem smokeAfter;
    GameObject fireHolder;
    GameObject smokeAfterHolder;
    //float rate = 10;

    //火要多久扑灭/火势凶不凶
    float size = 1;
    //灭火后烟过多久消失
    float smokeTime = 8;

    public GameObject ground;
    public GameObject resourcebox;

    // Start is called before the first frame update
    void Start()
    {
        ground = GameObject.Find("PaintableGround");
        resourcebox = GameObject.Find("ResourceCenter");
        Physics.IgnoreCollision(ground.GetComponent<Collider>(), GetComponent<Collider>());
        Physics.IgnoreCollision(resourcebox.GetComponent<Collider>(), GetComponent<Collider>());
        fire = transform.GetChild(0).GetComponent<ParticleSystem>();
        smoke = transform.GetChild(0).GetChild(0).GetComponent<ParticleSystem>();
        smokeAfter = transform.GetChild(1).GetComponent<ParticleSystem>();
        fireHolder = transform.GetChild(0).gameObject;
        smokeAfterHolder = transform.GetChild(1).gameObject;
        smokeAfterHolder.SetActive(false);
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
            //Destroy(fireHolder);
            fire.Stop();
            smoke.Stop();
            smokeAfterHolder.SetActive(true);
            smokeTime -= .01f;
        }

        if (smokeTime <= 3)
        {
            smokeAfter.Stop();
        }
        if (smokeTime <= 0)
        {
            smokeTime = 0;
            Destroy(gameObject);
        }
    }

    // 触发着火
    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Fire Detected with "+ other.name);
        if (other.CompareTag("Rain") && size > 0)
        {
            Debug.Log("Rain hit fire");
            //var em = fire.emission;
            //rate -= .1f;
            //em.rateOverTime = rate;
            //Debug.Log(em.rateOverTime);
            //fire.emission = em;

            size -= 0.01f;
        }
    }
}
