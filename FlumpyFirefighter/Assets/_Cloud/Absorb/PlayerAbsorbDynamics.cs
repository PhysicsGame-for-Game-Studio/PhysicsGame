using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbsorbDynamics : MonoBehaviour
{
    public ParticleSystem rainParticle;
    public GameObject player;
    public float distance;
    ParticleSystem.MainModule main;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        main = rainParticle.main;

        
    }

    // Update is called once per frame
    void Update()
    {
        // get distane between player and water
        distance = player.transform.position.y - this.transform.position.y;

        // calculate how the relationship between the player and water so that the start lifetime always calculates
        // consistently with the player.
        main.startLifetime = (distance * .1f);

        //rainParticle.startLifetime = (distance * .1f);
    }
}
