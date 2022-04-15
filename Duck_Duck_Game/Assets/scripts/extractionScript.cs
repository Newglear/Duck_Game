using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class extractionScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Canvas endScreen;
    public duckBehaviour duckScript;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
           
    }

    void OnTriggerEnter2D( Collider2D other )
    {
        if ( other.gameObject.tag == "Player" )
        {
            /*if ( duckScript.canWin() )
            {
                endScreen.enabled = true;
//                 Debug.Log( "You win" );
                TMP_Text[] texts = endScreen.GetComponentsInChildren<TMP_Text>();
                texts[0].alpha = 0f;
                texts[1].alpha = 1f;
            }*/
        }
    }
}
