using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    public float TotalTime = 10f;
    public float MaxTime = 10f;
    AudioSource a;
    public AudioClip clip;
    bool played=false;
    public GameObject endings;
    public Image clock;
    public float lerpSpeed = 0.1f;


    void Start()
    {
        StartCoroutine(CoutDownFun());
        endings.SetActive(false);
    }

    private void Update()
    {
        clock.fillAmount = Mathf.Lerp(clock.fillAmount, TotalTime / MaxTime, lerpSpeed);


        if (TotalTime <= 0f)
        {
            if (!played)
            {
                //a.clip = clip;
                //a.Play();
                //a.volume = .8f;
                played = true;
                endings.SetActive(true);
            }
        }
    }

    IEnumerator CoutDownFun()
    {
        while (TotalTime > 0)
        {

            yield return new WaitForSeconds(1);
            TotalTime--;
        }

    }
}
