using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetDestinationDepth : MonoBehaviour
{
    public ButtonAnimation animatedButton;
    public MoveElevator destination;
    public ShowCanvas showCanvas;
    public CanvasGroup referencePanel;

    public float depth;

    void Start()
    {
        animatedButton.OnButtonPressed += SetDepth;
        
    }

    
    public void SetDepth()
    {
        destination.destinationDepth = depth;
        destination.DisablePanels();
        if(referencePanel != null)
        {
            showCanvas.activePanel = referencePanel;
        }
        
    }

}
