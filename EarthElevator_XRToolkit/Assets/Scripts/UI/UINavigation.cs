using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;

public class UINavigation : MonoBehaviour
{
    public Canvas infoUI;
    public CanvasGroup nextPanel;
    



    public void UIActionStandard()
    {
               
        if (nextPanel != null)
        {
            foreach (CanvasGroup panel in infoUI.GetComponentsInChildren<CanvasGroup>())
            {
                panel.DOFade(0f, 1.0f);
                panel.interactable = false;
                panel.blocksRaycasts = false;
            }

            nextPanel.DOFade(1f, 1.0f);
            nextPanel.interactable = true;
            nextPanel.blocksRaycasts = true;

                                  

        }
        

    }

    
}

