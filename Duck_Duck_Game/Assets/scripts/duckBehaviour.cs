using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class duckBehaviour : MonoBehaviour
{
    private AudioSource HonkSource;
    private float lastHonkTime;
    public float HonkInterval;
    public ParticleSystem deathParticles;
    public followDuck finger;
    // Start is called before the first frame update
    void Start()
    {
        lastHonkTime = Time.time;
        HonkSource = GetComponent<AudioSource>();
        HonkSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if ( Time.time - HonkInterval >= lastHonkTime )
        {
            HonkSource.Play();
            lastHonkTime = Time.time;
            if ( finger.seePlayer() )
            {
                die();
            }
        }
    }

    public float HonkProgress()
    {
        return ( Time.time - lastHonkTime ) / HonkInterval;
    }

    public void die()
    {
        deathParticles.Play();
    }
}
