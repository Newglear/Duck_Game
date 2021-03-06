using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followDuck : MonoBehaviour
{
    public Transform duck;
    public Transform parent;
    private Transform finger;

    public ParticleSystem atSymbolSwears;
    public ParticleSystem poundSymbolSwears;

    public SpriteRenderer guy;
    private SpriteRenderer sprite;

    public Sprite guyWithArms;
    public Sprite guyWithoutArm;

    public float VisionRange;
    private bool inVision;
    static private int VisionCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        finger = GetComponent<Transform>();
        sprite = GetComponent<SpriteRenderer>();
        inVision = false;
        atSymbolSwears.Pause();
        poundSymbolSwears.Pause();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = duck.position - parent.position;
        RaycastHit2D hit = Physics2D.Raycast( transform.position, direction, VisionRange );
        if ( hit.collider != null )
        {
//             Debug.Log( hit.collider.tag );
            if ( hit.collider.tag != "Player" )
            {
                hideFinger();
            }
            else
            {
                sprite.enabled = true;
                finger.right = -direction.normalized;
                guy.sprite = guyWithoutArm;
                if ( !inVision )
                {
                    inVision = true;
                    VisionCount++;
                }
                atSymbolSwears.Play();
                poundSymbolSwears.Play();
            }
        }
        else
        {
            hideFinger();
        }
    }

    private void hideFinger()
    {
        if ( inVision )
        {
            inVision = false;
            VisionCount--;
        }
        sprite.enabled = false;
        guy.sprite = guyWithArms;
        atSymbolSwears.Pause();
        poundSymbolSwears.Pause();
        atSymbolSwears.Clear();
        poundSymbolSwears.Clear();
    }

    public bool seePlayer()
    {
        return VisionCount > 0;
    }
}
