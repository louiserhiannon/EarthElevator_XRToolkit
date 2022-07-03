using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelSetUp : MonoBehaviour
{
    public Sprite inactiveButton;
    public List<Image> consoleImages;

    void Awake()
    {
        ResetPanels();
    }

    public void ResetPanels()
    {
        for (int i = 0; i < consoleImages.Count; i++)
        {
            consoleImages[i].sprite = inactiveButton;
        }
    }

    
}
