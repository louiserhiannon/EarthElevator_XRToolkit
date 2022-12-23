using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PTMarkerUI : MonoBehaviour
{
    public meltingPTInputCalcs inputCalcs;
    private float depth;
    private float maxDepth = 200f;
    private float temp;
    private float maxTemp = 2000f;
    private RectTransform PTMarker;
    private float markerPosDepth;
    private float markerPosTemp;
    private float markerPosDepthRange;
    private float markerPosDepthMax;
    private float markerPosDepthMin;
    private float markerPosTempRange;
    private float markerPosTempMax;
    private float markerPosTempMin;
    
    

    void Start()
    {
        PTMarker = GetComponent<RectTransform>();
        markerPosDepthMax = 380f;
        markerPosDepthMin = -515f;
        markerPosTempMax = 518f;
        markerPosTempMin = -385f;

        SetPTMarker();

    }

    void Update()
    {
        SetPTMarker();
    }

    private void SetPTMarker()
    {
        depth = inputCalcs.depth;
        markerPosDepthRange = markerPosDepthMax - markerPosDepthMin;
        markerPosDepth = markerPosDepthMax - depth / maxDepth * markerPosDepthRange;
        temp = inputCalcs.temp;
        markerPosTempRange = markerPosTempMax - markerPosTempMin;
        markerPosTemp = markerPosTempMin + temp / maxTemp * markerPosTempRange;
        PTMarker.anchoredPosition = new Vector2(markerPosTemp, markerPosDepth);
    }
}
