using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class deathCounter : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    private int deathCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty;       
        showDeaths();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void incrementDeaths()
    {
        deathCount++;
        showDeaths();
    }

    private void showDeaths()
    {
        textComponent.text = "Deaths : " + deathCount.ToString();
    }
}
