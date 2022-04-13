using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roll : MonoBehaviour
{
    public Collider2D box,sphere; 
    public bool isRolling = false;
    public Transform duck; 
    public float rollSpeed; 
    float horizontal; 
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R)){
            if(!isRolling){
            box.enabled = false;
            sphere.enabled =true;
            horizontal = Input.GetAxisRaw("Horizontal");
            duck.Rotate(new Vector3(0,0,horizontal*rollSpeed));
            }else{
            box.enabled = true;
            sphere.enabled =false;
            }


        }
    }
}
