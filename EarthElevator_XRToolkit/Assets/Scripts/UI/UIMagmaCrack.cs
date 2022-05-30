using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;

public class UIMagmaCrack : MonoBehaviour
{
    //private VRInput controller;
    //public CanvasGroup thisPanelActive;
    public Canvas infoUI;
    public Canvas trophyUI;
    public CanvasGroup trophyHandlensPanel;
    
    public AudioSource audioSource;
    public AudioClip earthquakeSound;
    public AudioClip congratulationsSound;


    public float pauseBeforeCrack = 3f;
    public GameObject groundCrackPrefab;
    public GameObject handlensPrefab;
    public Transform groundCrackPosition;
    public Transform handlensPosition;
    private Vector3 startScaleCrack;
    
    private Vector3 endScaleCrack;
    public float crackGrowthDuration = 10f;
    public float pauseBeforeTrophy = 6f;
    public float pauseAfterTrophy = 10f;
    private float pauseBeforeInstantiate = 6f;

   
    public void UIActionMagmaCrack()
    {
        foreach (CanvasGroup panel in infoUI.GetComponentsInChildren<CanvasGroup>())
        {
            panel.DOFade(0f, 1.0f);
            panel.interactable = false;
            panel.blocksRaycasts = false;
        }


        StartCoroutine(GroundCrack());
    }


    private IEnumerator GroundCrack()
    {
        yield return new WaitForSeconds(pauseBeforeCrack);

        GameObject groundCrack = Instantiate(groundCrackPrefab, groundCrackPosition);
        groundCrack.transform.localScale = startScaleCrack;
        audioSource.PlayOneShot(earthquakeSound);
        groundCrack.transform.DOScale(endScaleCrack, crackGrowthDuration);

        yield return new WaitForSeconds(crackGrowthDuration);

        audioSource.Stop();

        yield return new WaitForSeconds(pauseBeforeTrophy);

        //Display Earn Trophy UI
        CongratulationsHandlens();

        yield return new WaitForSeconds(pauseBeforeInstantiate);

        //instantiate handlens
        GameObject handlens = Instantiate(handlensPrefab, handlensPosition);

        yield return new WaitForSeconds(pauseAfterTrophy);

        TrophyPanelDisappear();

    }

    private void CongratulationsHandlens()
    {
        audioSource.PlayOneShot(congratulationsSound);
        Debug.Log("Select sounds should be playing");

        trophyHandlensPanel.DOFade(1f, 0.5f);

    }

    private void TrophyPanelDisappear()
    {
        foreach (CanvasGroup panel in trophyUI.GetComponentsInChildren<CanvasGroup>())
        {
            panel.DOFade(0f, 0.5f);
            panel.interactable = false;
            panel.blocksRaycasts = false;
        }
    }
}

