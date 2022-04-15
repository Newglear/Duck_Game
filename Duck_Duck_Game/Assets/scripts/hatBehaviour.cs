using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hatBehaviour : MonoBehaviour
{
//     private SpriteRenderer m_Renderer;
    private Collider2D col;
    private SpriteRenderer hatSprite;
    public ParticleSystem shine;
    // Start is called before the first frame update
    void Start()
    {
        hatSprite = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D( Collision2D collision )
    {
        if ( collision.gameObject.tag == "Player" )
        {
            hatSprite.enabled = false;
            col.enabled = false;
            shine.Pause();
            shine.Clear();
        }
    }
    public void Init (){
        hatSprite.enabled = true;
        col.enabled = true;
        shine.Play();
    }
}
