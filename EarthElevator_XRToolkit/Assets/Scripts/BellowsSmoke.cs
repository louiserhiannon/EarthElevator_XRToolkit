using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BellowsSmoke : MonoBehaviour
{
    public LeverAngle leverAngle;
    private ParticleSystem smoke;
    private float newLeverValue;
    private float lastLeverValue;
    public float tempAdjust;
    

    void Awake()
    {
        smoke = GetComponent<ParticleSystem>();
    }

    private void Start()
    {
        lastLeverValue = 0f;
        tempAdjust = 0f;
    }

    void Update()
    {
        newLeverValue = leverAngle.leverValue;
        //Generate Smoke and update temperature
        
        if (newLeverValue < lastLeverValue - 0.05)
        {
            smoke.Play();
            tempAdjust = 10f;
        }
        else
        {
        tempAdjust = -0.05f;
        }
        
        lastLeverValue = newLeverValue;

    }

   
}
