using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrewMovement : MonoBehaviour
{
    public ScrewAngle screwAngle;
    private float screwMaxY;
    private float screwMinY;
    public float screwY;
    public float screwRelativePos;
    private Vector3 screwTopPosition;
    private Vector3 screwBottomPosition;
    private Vector3 screwInitialPosition;
    private float maxDepth;
    private float initialDepth;
    private float initialPositionY;
    public float depth;
    


    private void Start()
    {
        screwMaxY = 0.232f;
        screwMinY = 0.167f;
        maxDepth = 200f;
        initialDepth = 170f;



        //Set Position

        initialPositionY = screwMaxY - (screwMaxY - screwMinY) * initialDepth / maxDepth;
        screwInitialPosition = new Vector3(0, initialPositionY, 0);
        transform.localPosition = screwInitialPosition;

        //Set Limits
        screwTopPosition = new Vector3(0, (screwMaxY - 0.0002f), 0);
        screwBottomPosition = new Vector3(0, (screwMinY + 0.0002f), 0);
    }
    void Update()
    {
        //move screw between min and max positions
        if(transform.localPosition.y <= screwMaxY && transform.localPosition.y >= screwMinY)
        {
            transform.Translate(0, 0, screwAngle.distance);
        }
        else if (transform.position.y > screwMaxY)
        {
            transform.localPosition = screwTopPosition;
        }
        else if (transform.position.y < screwMinY)
        {
            transform.localPosition = screwBottomPosition;
        }


        //calculate relative position
        screwY = transform.localPosition.y;
        screwRelativePos = (screwY - screwMaxY) / (screwMinY - screwMaxY);

        //calculate equivalent depth
        depth = maxDepth * screwRelativePos;

    }
}
