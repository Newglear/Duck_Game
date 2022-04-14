using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hatBehaviour : MonoBehaviour
{
    private SpriteRenderer m_Renderer;
    // Start is called before the first frame update
    void Start()
    {
        m_Renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D( Collision2D collision )
    {
        if ( collision.gameObject.tag == "Player" )
        {
            m_Renderer.enabled = false;
        }
    }
}
