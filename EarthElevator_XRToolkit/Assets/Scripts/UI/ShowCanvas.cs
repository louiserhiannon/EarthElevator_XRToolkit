using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.UI;


//https://www.youtube.com/watch?v=m5WsmlEOFiA
public class ShowCanvas : MonoBehaviour
{
    private ActionBasedController controller;
    public CanvasGroup activePanel;



    private void Awake()
    {
        controller = GetComponent<ActionBasedController>();

        controller.activateAction.action.started += OpenUIReference;
        controller.activateAction.action.canceled += CloseUIReference;
    }
    //public void OnEnable()
    //{
                

    //    //controller.OnAButton.AddListener(OpenUIReference);
    //    //controller.OnAButtonUp.AddListener(CloseUIReference);
    //}

    //public void OnDisable()
    //{
    //    //controller.OnAButton.RemoveListener(OpenUIReference);
    //    //controller.OnAButtonUp.RemoveListener(CloseUIReference);
    //}

    public void OpenUIReference(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if (activePanel != null)
        {
            activePanel.alpha = 1;
            activePanel.interactable = true;
            activePanel.blocksRaycasts = true;

        }
    }

    public void CloseUIReference(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if (activePanel != null)
        {
            activePanel.alpha = 0;
            activePanel.interactable = false;
            activePanel.blocksRaycasts = false;

        }
    }
}
