using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SolidusController : MonoBehaviour
{
    public CanvasGroup drySolidus;
    public CanvasGroup wetSolidus;
    public WaterVolume waterVolume;
    public bool setSolidus;
    private float wetness;

    private void Start()
    {
        wetness = 0f;
        waterVolume = GetComponentInChildren<WaterVolume>(true);
        setSolidus = false;
    }

    //public void ShowDrySolidus()
    //{
    //    drySolidus.alpha = 1f;
    //    wetSolidus.alpha = 0f;
    //}


    //public void ShowWetSolidus()
    //{
    //    drySolidus.alpha = 0f;
    //    wetSolidus.alpha = 1f;
    //}


    // Update is called once per frame
    void Update()
    {
        if (setSolidus)
        {
            wetness = waterVolume.relativeWetness;

            if (wetness > 0.5)
            {
                drySolidus.alpha = 0f;

                wetSolidus.alpha = 1f;

            }

            drySolidus.alpha = 1 - wetness / 2;

            wetSolidus.alpha = wetness / 2;
        }
            
         

    }
}
