using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class honking : MonoBehaviour
{
    private AudioSource HonkSource;
    private float lastHonkTime;
    public float HonkInterval;
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
        }
    }

    public float HonkProgress()
    {
        return ( Time.time - lastHonkTime ) / HonkInterval;
    }
}
