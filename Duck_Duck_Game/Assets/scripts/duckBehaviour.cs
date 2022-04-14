using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class duckBehaviour : MonoBehaviour
{
    private AudioSource HonkSource;

    public ParticleSystem deathParticles;

    public followDuck finger;

    public Rigidbody2D rb;

    public SpriteRenderer m_Renderer;

    public Transform groundCheck;
    private Transform duckTransform;

    public Sprite duckWithHat;

    public LayerMask mask;

    public Canvas hud,end;

    private float deathTime =0f; 

    public float speed = 50f; 
    public float jumpHeight,jump;
    private float horizontal;
    public float groundDistance = 0.2f;
    public float flyEnergy=100f;
    private float lastHonkTime;
    public float HonkInterval;
    public float fallingSpeed;

    private bool isGrounded=true; 
    private bool dead = false;
    // Start is called before the first frame update
    void Start()
    {
        lastHonkTime = Time.time;
        HonkSource = GetComponent<AudioSource>();
        HonkSource.Play();
        rb = GetComponent<Rigidbody2D>();
        m_Renderer =GetComponent<SpriteRenderer>();
        duckTransform = GetComponent<Transform>();
        end.enabled=false;
    }

    // Update is called once per frame
    void Update()
    {
        movePlayer();
        calculateHonk();
        deathBehavior();    
    }

    void FixedUpdate(){
        checkGrounded();
    }

    void OnCollisionEnter2D( Collision2D collision )
    {
        if ( collision.gameObject.tag == "Hat" )
        {
            m_Renderer.sprite = duckWithHat;
        }
    }

    public float HonkProgress()
    {
        return ( Time.time - lastHonkTime ) / HonkInterval;
    }

    public void die()
    {
        deathTime=Time.time;
        deathParticles.Play();
        dead = true;
        hud.enabled=false;
    }
    
    private void checkGrounded()
    {
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

    private void movePlayer()
    {
        if ( !dead )
        {
            //Debug.Log(isGrounded);
            if(Input.GetButton("Jump") && isGrounded ){
    //             Debug.Log("Jump Called");
                //rb.AddForce(new Vector2(0,jumpHeight));
                rb.velocity = Vector2.up*jumpHeight;  
                isGrounded = false;
            } 
            if(Input.GetKey(KeyCode.LeftControl)){
                speed = 10 ; 
            }
            else{
                speed = 25;
            }
            horizontal = Input.GetAxisRaw("Horizontal"); // -1 is left
            if(horizontal==1)
                m_Renderer.flipX=true;
            else if ( horizontal == -1 )
                m_Renderer.flipX =false;
            rb.velocity =new Vector2(horizontal*speed,rb.velocity.y);
            duckTransform.up = Vector2.up;
        }
        else
        {
            duckTransform.up = Vector3.Lerp( duckTransform.up, -Vector2.right, fallingSpeed ).normalized;
        }
    }

    private void calculateHonk()
    {
        if ( !dead )
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
    }

    private void deathBehavior(){
        if(Time.time - deathTime > 3f && dead){
            
            end.enabled=true;
            TMP_Text[] texts = end.GetComponentsInChildren<TMP_Text>();
            texts[1].alpha = 0f;
        }
    }

}
