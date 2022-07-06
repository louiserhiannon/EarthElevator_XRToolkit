using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DepthGaugeUI : MonoBehaviour
{
    public MoveElevator elevator;
    public float depth;
    public float maxDepth = 6300f;
    public RectTransform elevatorMarker;
    public float markerPosY;
    private float markerPosYRange;
    private float markerPosYMax; 
    private float markerPosYMin;
        

    void Start()
    {
        elevatorMarker = GetComponent<RectTransform>();
        markerPosYMax = 0.590f;
        markerPosYMin = -0.640f;
        elevatorMarker.anchoredPosition = new Vector2(-0.0215f, markerPosYMax);
      
    }

    // Update is called once per frame
    void Update()
    {
        
        UpdateGauge();
    }

    private void UpdateGauge()
    {
        depth = elevator.currentDepth;
        markerPosYRange = markerPosYMax - markerPosYMin;
        markerPosY = markerPosYMax - depth / maxDepth * markerPosYRange;
        elevatorMarker.anchoredPosition = new Vector2(-0.0215f, markerPosY);

    }
}
