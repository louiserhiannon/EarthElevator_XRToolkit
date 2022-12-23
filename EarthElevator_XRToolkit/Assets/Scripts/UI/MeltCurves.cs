using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeltCurves : MonoBehaviour
{
    public float solidusTemperature;
    public float geothermTemperature;
    public float CalculateDrySolidus(float depth)
    {
        solidusTemperature = (float)(1088 + 5.05 * depth - 0.0172 * depth * depth + 0.0000246 * depth * depth * depth);
        return solidusTemperature;
    }

    public float CalculateWetSolidus(float depth)
    {
        if(depth <= 50f)
        {
            solidusTemperature = (float)(1080 - 43.6 * depth + 1.61 * depth * depth - 0.0259 * depth * depth * depth + 0.000156 * depth * depth * depth * depth);
        }
        else
        {
            solidusTemperature = (float)(584 + 0.974 * depth + 0.00582 * depth * depth);
        }
        return solidusTemperature;

    }

    public float CalculateGeotherm(float depth)
    {
        geothermTemperature = (float)(58.3 + 17.4 * depth - 0.0916 * depth * depth + 0.000192 * depth * depth * depth);
        return geothermTemperature;
    }

}
