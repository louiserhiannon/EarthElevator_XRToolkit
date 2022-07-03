using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedSliderPosition : MonoBehaviour
{
    public float normalizedSpeed;
    private Slider speedSlider;

    
    // Start is called before the first frame update
    void Start()
    {
        speedSlider = GetComponent<Slider>();
        speedSlider.value = 0.5f;
    }

        public void CalculateNormalizedSpeed()
    {
        normalizedSpeed = speedSlider.value;
    }
}
