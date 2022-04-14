using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class honks : MonoBehaviour
{
    private AudioSource HonkSource;
    // Start is called before the first frame update
    void Start()
    {
        HonkSource = GetComponent<AudioSource>();   
    }

    // Update is called once per frame
    void Update()
    {
    }
}
