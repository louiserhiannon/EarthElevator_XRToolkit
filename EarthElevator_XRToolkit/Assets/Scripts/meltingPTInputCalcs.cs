using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meltingPTInputCalcs : MonoBehaviour
{
    public MeltCurves meltcurves;
    [SerializeField]
    private ScrewMovement depthInput;
    [SerializeField]
    private BellowsSmoke tempInput;
    public float temp;
    public float depth;
    private float minTemp;
    // Start is called before the first frame update
    void Start()
    {
        depth = 170f;
        temp = meltcurves.CalculateGeotherm(depth);

        tempInput = GetComponentInChildren<BellowsSmoke>(true);
        depthInput = GetComponentInChildren<ScrewMovement>(true);

    }

    void Update()
    {
        depth = Mathf.Clamp(depthInput.depth, 0f, 200f);
        minTemp = meltcurves.CalculateGeotherm(depth);
        temp += tempInput.tempAdjust;
        temp = Mathf.Clamp(temp, minTemp, 2000f);

    }
}
