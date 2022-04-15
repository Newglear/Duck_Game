using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Rigidbody2D rb;
    public SpriteRenderer render;
    public float speed = 50f; 
    public float jumpHeight,jump;
    private float horizontal;
    private bool isGrounded=true; 
    public LayerMask mask;
    public Transform groundCheck;
    public float groundDistance = 0.2f;
    public float flyEnergy=100f;
    public bool isRolling;
    private bool isWalking = false;
    public Animator Anim; 
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        render =GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(isGrounded);
        if(Input.GetButton("Jump") && isGrounded ){
            Debug.Log("Jump Called");
            //rb.AddForce(new Vector2(0,jumpHeight));
            rb.velocity += Vector2.up*jumpHeight;  
            isGrounded = false;
        } 
        if(Input.GetKey(KeyCode.LeftControl)){
            speed = 10 ; 
        }
        else{
            speed = 25;
        }
        horizontal = Input.GetAxisRaw("Horizontal"); // -1 is left
        if(Input.GetKeyDown(KeyCode.R)){
            isRolling = true;
        }else{
            isRolling = false;
        }
        if(render){
            if(horizontal==1)
                render.flipX=true;
            else
                render.flipX =false;
        }
        isWalking = (horizontal != 0);
        Anim.SetBool("isWalking",isWalking);
        rb.velocity =new Vector2(horizontal*speed,rb.velocity.y);
        
    }
    void FixedUpdate(){
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, groundDistance);
        //Check if any of the overlapping colliders are not player collider, if so, set isGrounded to true
        isGrounded = false;
        if (colliders.Length > 0)
        {
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].gameObject.layer == LayerMask.NameToLayer("Ground"))
                {
                    isGrounded = true;
                    break;
                }
                else{
                    isGrounded =false;
                }
            }
        }
        
    }
    
}
