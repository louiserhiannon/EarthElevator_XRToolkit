using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBlackHole : MonoBehaviour
{
    //Moves Upper Black hole up to final position at beginning of movement and back towards elevator when coming back to the surface

    private Vector3 finalPosition = new Vector3(0f, 90f, 0f);
    private Vector3 resetPosition = new Vector3(0f, 10f, 0f);
    public Transform shaftMovement;

    public void MoveBlackHoleWithShaft(Transform activePoint)
    {
        transform.SetParent(activePoint.transform);
        transform.position = resetPosition;

    }

    public void SetBlackHoleTransform()
    {
        //set position
        transform.SetParent(shaftMovement);
        transform.position = finalPosition;
    }
}
