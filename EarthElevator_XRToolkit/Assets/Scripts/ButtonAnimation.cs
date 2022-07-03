using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.UI;

public class ButtonAnimation : MonoBehaviour
{
    public delegate void ButtonPressedEvent();
    public ButtonPressedEvent OnButtonPressed;
    public PanelSetUp panelReset;

    //private Animator buttonAnim;
    public ButtonPressHandAnimation leftHand;
    public ButtonPressHandAnimation rightHand;

    private Sprite thisImage;
    public Sprite activeButton;


    void Awake()
    {
        thisImage = GetComponent<Sprite>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerLeft" || other.tag == "PlayerRight")
        {
            OnButtonPressed();
            IlluminateButton();
            //buttonAnim.SetTrigger("Pressed");
            if(other.tag == "PlayerLeft")
            {
                leftHand.PointFinger();
            }
            else if(other.tag == "PlayerRight")
            {
                rightHand.PointFinger();
            }
            
        }
    }

    private void IlluminateButton()
    {
        //for each image in a certain set, make sure that they're "inactive" version
        panelReset.ResetPanels();

        //for pressed button, change to active button
        thisImage = activeButton;


    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "PlayerLeft" || other.tag == "PlayerRight")
        {
            //buttonAnim.SetTrigger("Released");
            if (other.tag == "PlayerLeft")
            {
                leftHand.UnpointFinger();
            }
            else if (other.tag == "PlayerRight")
            {
                rightHand.UnpointFinger();
            }

        }
    }
}
