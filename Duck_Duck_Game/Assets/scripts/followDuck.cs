using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followDuck : MonoBehaviour
{
    public Transform duck;
    public Transform parent;
    public SpriteRenderer guy;
    public Sprite guyWithArms;
    public Sprite guyWithoutArm;
    private Transform finger;
    private SpriteRenderer sprite;
    public float VisionRange;
    private bool inVision;
    // Start is called before the first frame update
    void Start()
    {
        finger = GetComponent<Transform>();
        sprite = GetComponent<SpriteRenderer>();
        inVision = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = duck.position - parent.position;
        RaycastHit2D hit = Physics2D.Raycast( transform.position, direction, VisionRange );
        if ( hit.collider != null )
        {
            if ( hit.collider.tag != "Player" )
            {
                hideFinger();
            }
            else
            {
                sprite.enabled = true;
                finger.right = -direction.normalized;
                guy.sprite = guyWithoutArm;
                inVision = true;
            }
        }
        else
        {
            hideFinger();
        }
    }

    private void hideFinger()
    {
        inVision = false;
        sprite.enabled = false;
        guy.sprite = guyWithArms;
    }

    public bool seePlayer()
    {
        return inVision;
    }
}
