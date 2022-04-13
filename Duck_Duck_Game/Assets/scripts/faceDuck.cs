using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class faceDuck : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform duck;
    private Transform thisTransform;
    public SpriteRenderer fingerSprite;
    void Start()
    {
        thisTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if ( ( duck.position.x - thisTransform.position.x ) / thisTransform.right.x >= 0 )
        {
            thisTransform.right = -thisTransform.right;
            fingerSprite.flipY = !fingerSprite.flipY;
        }
    }
}
