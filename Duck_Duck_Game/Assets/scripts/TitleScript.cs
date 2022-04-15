using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScript : MonoBehaviour
{
    public Canvas main,title,controls,rules;

    // Start is called before the first frame update
    void Start()
    {
        title.enabled = true;
        main.enabled =false; 
        controls.enabled=false; 
        rules.enabled =false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKey){
            main.enabled =true; 
            title.enabled =false;
        }
    }
}
