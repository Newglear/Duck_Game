using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class honkBar : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider slider;
    private float currentValue = 0f;
    public float CurrentValue
    {
        get {
            return currentValue;
        }
        set {
            currentValue = value;
            slider.value = currentValue;
        }
    }
    public duckBehaviour honkingScript;
    void Start()
    {
        CurrentValue = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        CurrentValue = honkingScript.HonkProgress();
    }
}
