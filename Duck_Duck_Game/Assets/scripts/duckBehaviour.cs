using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class duckBehaviour : MonoBehaviour
{
    private AudioSource HonkSource;

    public ParticleSystem deathParticles;

    public followDuck finger;
    public deathCounter deaths;

    public Rigidbody2D rb;

    public SpriteRenderer m_Renderer;

    public Transform groundCheck;
    private Transform duckTransform;
    public Transform spawner;

    public Sprite duckWithHat;

    public Canvas hud,end;

    public Animator Anim;

    private float deathTime =0f; 

    private float speed;
    public float normalSpeed;
    public float maxSpeed = 40f;
    public float jumpHeight,jump;
    private float horizontal;
    public float groundDistance = 0.2f;
    public float flyEnergy=100f;
    private float lastHonkTime;
    public float HonkInterval;
    public float fallingSpeed;
    public float dashDistance = 10f;
    public float crouchSpeed= 15;

    private bool isGrounded=true; 
    private bool dead = false;
    private bool dashOnCooldown;
    private float timeDash; 
    private bool hasHat = false;
    // Start is called before the first frame update
    void Start()
    {
        Init();
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
            hasHat = true;
            Anim.SetBool("hasHat",true);
        }
    }

    public float HonkProgress()
    {
        return ( Time.time - lastHonkTime ) / HonkInterval;
    }

    public void die()
    {
        deaths.incrementDeaths();
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
            }
        }
    }

    private void movePlayer()
    {
        if ( !dead )
        {
            //Debug.Log(isGrounded);
            if(Input.GetButton("Jump") && isGrounded ){
                //Debug.Log("Jump Called");
                //rb.AddForce(new Vector2(0,jumpHeight));
                rb.velocity = Vector2.up*jumpHeight;  
                isGrounded = false;
            }
            if(Input.GetKey(KeyCode.LeftControl)) 
                Crouch();
            else if(Input.GetKey(KeyCode.LeftShift))    
                Accelerate();
            if(!Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.LeftControl))
                Decelerate();
                
            if(Input.GetButton("Dash")&& horizontal !=0)
                duckduckDash();
            horizontal = Input.GetAxisRaw("Horizontal"); // -1 is left
            Animate();
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

    private void duckduckDash(){
        
        if(!dashOnCooldown)
        {
            for(int i=0; i<5;i++){
                StartCoroutine(dash());
            }
            
            dashOnCooldown = true;
            timeDash = Time.time;
        }
        else{
            dashOnCooldown = ((Time.time - timeDash ) < 1f);
        }
            
    }
    IEnumerator dash(){
        rb.AddForce(new Vector2(horizontal * dashDistance/5 , 0f));
        yield return new WaitForSeconds(0.6f);
    }
    private void Accelerate(){
        float deltaSpeed = maxSpeed /25f;
//         Debug.Log(deltaSpeed);
        if(speed < maxSpeed)
        {
//             Debug.Log("Increasing");
            speed += deltaSpeed;
//             Debug.Log(speed);
        }
            
        else{
//             Debug.Log("MAX");
            speed = maxSpeed;
        }
            
    }
    private void Decelerate(){
        float deltaSpeed = maxSpeed /25f;
//         Debug.Log(deltaSpeed);
        if(speed > normalSpeed)
        {
//             Debug.Log("Decreasing");
            speed -= deltaSpeed;
//             Debug.Log(speed);
        }
            
        else{
//             Debug.Log("MIN");
            speed = normalSpeed;
        }
            
    }
    
    private void Crouch(){
        speed = crouchSpeed;
    }
    private void Animate(){
        Anim.SetBool("isWalking",horizontal != 0f);
        Anim.SetBool("isRunning",Input.GetKey(KeyCode.LeftShift));
        Anim.SetBool("Jump",!isGrounded);
        Anim.SetBool("Crouch",Input.GetKey(KeyCode.LeftControl));
    }

    public bool canWin()
    {
        return hasHat;
    }
    public bool getDead(){
        return dead;
    }
    public bool getEnd(){
        return end.enabled;
    }
    public void Init(){
        lastHonkTime = Time.time;
        HonkSource = GetComponent<AudioSource>();
        HonkSource.Play();
        rb = GetComponent<Rigidbody2D>();
        m_Renderer =GetComponent<SpriteRenderer>();
        duckTransform = GetComponent<Transform>();
        end.enabled=false;
        hud.enabled =true;
        dashOnCooldown = false;
        Anim.SetBool( "hasHat", false );
        duckTransform.position =  spawner.position;
        dead =false;
        deathParticles.Pause();
        deathParticles.Clear();

    }
}
