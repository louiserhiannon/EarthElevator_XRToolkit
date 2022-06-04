using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ButtonPressHandAnimation : MonoBehaviour
{
    [SerializeField]
    private string pointingAnimationParameter;
    [SerializeField]
    private XRDirectInteractor directInteractor;
    public HandPrefab handPrefab;

    private void Awake()
    {
        directInteractor = GetComponent<XRDirectInteractor>();
    }


    public void PointFinger()
    {
        if (handPrefab == null)
        {
            handPrefab = directInteractor.GetComponentInChildren<HandPrefab>();
        }

        if (handPrefab != null)
        {
            handPrefab.Animator.SetBool(pointingAnimationParameter, true);
        }
    }

    public void UnpointFinger()
    {
        if (handPrefab == null)
        {
            handPrefab = directInteractor.GetComponentInChildren<HandPrefab>();
        }

        if (handPrefab != null)
        {
            handPrefab.Animator.SetBool(pointingAnimationParameter, false);
        }
    }
}
