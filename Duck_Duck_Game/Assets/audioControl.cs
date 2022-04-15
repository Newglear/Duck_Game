using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioControl : MonoBehaviour
{
    enum sounds {music,follow,death};
    private sounds current =sounds.music;
    public AudioClip[] clips;
    private AudioSource source;
    public duckBehaviour duck;
    public followDuck guy;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        source.clip = clips[(int)current];
        source.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(guy.seePlayer()&& current != sounds.follow && !duck.getDead()){
            current = sounds.follow;
            source.loop = true;
            source.volume = 0.1f;
            source.Pause(); 
            source.clip = clips[(int)current];
            source.Play(); 
        }
        if(duck.getDead()&& current != sounds.death){
            current = sounds.death;
            source.Pause();
            source.clip = clips[(int)current];
            source.Play();
            source.loop = false; 
        }
        if(!guy.seePlayer()&& current!=sounds.music && !duck.getDead()){
            current = sounds.music;
            source.loop = true;
            source.Pause();
            source.clip = clips[(int)current];
            source.Play(); 
        }

        
    }
}
