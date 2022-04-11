    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rbMove : MonoBehaviour
{
    public Rigidbody rb; 
    private Vector3 mousepos;
    public Camera cam;
    float horizontal;
    float vertical;
    public float Speed = 10f;
    public float JumpHeight = 5f;
    float moveLimiter = 0.7f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        mousepos = cam.ScreenToWorldPoint(Input.mousePosition);
        mousepos.y= 0f;
        Vector3 cursorVect = mousepos - rb.position; 
        float angle = Vector3.SignedAngle(transform.TransformDirection(Vector3.forward),cursorVect,Vector3.up);
        
        if(Mathf.Abs(angle)>=2f){
            rb.transform.Rotate(0f,angle*10*Time.deltaTime,0f);
        }
       
        if(Input.GetButtonDown("Jump")){
            rb.AddForce(0,JumpHeight,0,ForceMode.Impulse);
        } 
        horizontal = Input.GetAxisRaw("Horizontal"); // -1 is left
        vertical = Input.GetAxisRaw("Vertical"); // -1 is down
        if (horizontal != 0 && vertical != 0) // Check for diagonal movement
        {
            // limit movement speed diagonally, so you move at 70% speed
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        } 
        rb.velocity =new Vector3(horizontal*Speed,0,vertical*Speed);

        //rb.MovePosition(rb.position + (transform.forward * Input.GetAxis("Vertical") * Speed*Time.deltaTime) + (transform.right * Input.GetAxis("Horizontal") *  Speed *Time.deltaTime));
    }
}   
    