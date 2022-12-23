using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateElevatorPanel : MonoBehaviour
{
    public Transform panelPivot;
    private Vector3 rotateAxis = new Vector3(1f, 0f, 0f);
    public float panelAngle;
    private float panelAngleMax = 60f;
    private float pauseBeforeRotate = 5f;
    private float rotateSpeed = 10f;
    
    void Start()
    {
        panelAngle = 0f;
        StartCoroutine(ActivatePanel());
    }

    public void ReactivatePanel(float angle)
    {
        SetPanelAngle(angle);
        pauseBeforeRotate = 2f;
        StartCoroutine(ActivatePanel());
    }
    
    private IEnumerator ActivatePanel()
    {
        yield return new WaitForSeconds(pauseBeforeRotate);

        //Play Sound

        while (panelAngle < panelAngleMax)
        {
            transform.RotateAround(panelPivot.position, rotateAxis, rotateSpeed * Time.deltaTime);
            panelAngle += rotateSpeed * Time.deltaTime;

            yield return null;
        }

        //Stop Sound
    }

    private void SetPanelAngle(float angle)
    {
        panelAngle = angle;
    }

    
}
