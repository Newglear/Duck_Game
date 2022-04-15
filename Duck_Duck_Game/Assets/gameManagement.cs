using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManagement : MonoBehaviour
{
    public duckBehaviour duck; 
    public Transform spawner;
    public extractionScript extract; 
    public GameObject ducky;
    void Start()
    {
        
    }

    void Update()
    {
        if(duck.getDead()){
            if(Input.GetButtonDown("Retry")&& duck.getEnd()){   
                duck.Init();

            }
        }
    }
}
