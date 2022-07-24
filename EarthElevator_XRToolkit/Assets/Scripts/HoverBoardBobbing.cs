using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverBoardBobbing : MonoBehaviour
{
    public float maxAmplitude = 0.01f;
    public float oscillationFrequencyX = 10f;
    public float oscillationFrequencyY = 10f;
    public float oscillationFrequencyZ = 10f;
    public float oscillationOffset01 = 30f;
    public float oscillationOffset02 = 45f;
    public float yAdjustment = 0.5f;


    private Vector3 oscillationPosition;

    // Start is called before the first frame update
    void Start()
    {
        oscillationPosition = new Vector3(0, 0, 0);
        transform.localPosition = oscillationPosition;
    }

    // Update is called once per frame
    void Update()
    {
        oscillationPosition.x = maxAmplitude * Mathf.Cos(Time.time * oscillationFrequencyX);
        oscillationPosition.y = maxAmplitude * yAdjustment * Mathf.Cos(Time.time * oscillationFrequencyY + oscillationOffset01);
        oscillationPosition.z = maxAmplitude * Mathf.Cos(Time.time * oscillationFrequencyZ + oscillationOffset02);

        transform.localPosition = oscillationPosition;
    }
}
