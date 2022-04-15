using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class extractionScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Canvas endScreen;
    public duckBehaviour duckScript;
    private float timeWait;
    private bool won=false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(won);
        if(won && (  Time.time - timeWait  >5f)){
            
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
        }  
    }

    void OnTriggerEnter2D( Collider2D other )
    {
        if ( other.gameObject.tag == "Player" )
        {
            if ( duckScript.canWin() )
            {
                endScreen.enabled = true;
//                 Debug.Log( "You win" );
                TMP_Text[] texts = endScreen.GetComponentsInChildren<TMP_Text>();
                texts[0].alpha = 0f;
                texts[1].alpha = 1f;
                won= true;
                timeWait = Time.time;
            }
        }
    }
}
