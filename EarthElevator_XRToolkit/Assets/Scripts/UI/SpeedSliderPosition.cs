using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedSliderPosition : MonoBehaviour
{
    public float normalizedSpeed;
    private Scrollbar speedSlider;

    
    // Start is called before the first frame update
    void Start()
    {
        speedSlider = GetComponent<Scrollbar>();
        speedSlider.value = 0.5f;
    }

        public void CalculateNormalizedSpeed()
    {
        normalizedSpeed = speedSlider.value;
    }
}
