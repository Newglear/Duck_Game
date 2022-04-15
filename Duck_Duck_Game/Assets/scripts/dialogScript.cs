using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class dialogScript : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public float textSpeed;

    private bool talking;
    private string currentline;
    private bool stillWriting;
    // Start is called before the first frame update
    void Start()
    {
        stillWriting = false;
        textComponent.text = string.Empty;
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if ( stillWriting && textComponent.text == currentline )
        {
            StopAllCoroutines();
            currentline = string.Empty;
            stillWriting = false;
        }
    }

    public void startDialogue( string line )
    {
        gameObject.SetActive(true);
        stillWriting = true;
        currentline = line;
        StartCoroutine( TypeLine() );
    }

    IEnumerator TypeLine()
    {
        foreach ( char c in currentline.ToCharArray() )
        {
            textComponent.text += c;
            yield return new WaitForSeconds( textSpeed );
        }
    }
    
    public void stopDialogue()
    {
        textComponent.text = string.Empty;
        gameObject.SetActive(false);
    }
}
