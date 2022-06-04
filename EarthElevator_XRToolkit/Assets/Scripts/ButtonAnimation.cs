using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ButtonAnimation : MonoBehaviour
{
    public delegate void ButtonPressedEvent();
    public ButtonPressedEvent OnButtonPressed;

    private Animator buttonAnim;
    public ButtonPressHandAnimation leftHand;
    public ButtonPressHandAnimation rightHand;


    void Awake()
    {
        buttonAnim = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerLeft" || other.tag == "PlayerRight")
        {
            OnButtonPressed();
            buttonAnim.SetTrigger("Pressed");
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

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "PlayerLeft" || other.tag == "PlayerRight")
        {
            buttonAnim.SetTrigger("Released");
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
