using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MeltingLevelSetup : MonoBehaviour
{
    public List<Transform> objectSpawnPoints;
    public List<GameObject> objectPrefabs;
    public List<GameObject> spawnedObjects = new List<GameObject>();
    [SerializeField]
    private float blendWeight;
    public GameObject tableLeftPrefab;
    public GameObject tableRightPrefab;
    private GameObject tableLeft;
    private GameObject tableRight;
    public Transform tableTransform;
    public GameObject panelNEW;
    public Transform panelPivotNEW;
    private Vector3 rotateAxisNEW = new Vector3(1f, 0f, 0f);
    private float panelAngleNEW;
    private float rotateSpeedNEW = 10f;
    private SkinnedMeshRenderer rendererTableLeft;
    private SkinnedMeshRenderer rendererTableRight;
    private Mesh skinnedMeshLeft;
    private float buildSpeed = 75f;
    private float pauseBeforePanelRetract = 3f;
    private float pauseBeforeTableBuild = 1f;
    private float pauseBetweenTableSections = 0.5f;
    private float pauseBeforeSpawn = 2f;
    private float pauseBeforePanel = 1f;
    public Canvas meltingCanvas;

    public MoveElevator moveElevator;
    public SolidusController solidus;


    // Start is called before the first frame update
    void Awake()
    {
        blendWeight = 0f;
        tableLeft = Instantiate(tableLeftPrefab, tableTransform);
        tableRight = Instantiate(tableRightPrefab, tableTransform);
        
        for (int i = 0; i < objectPrefabs.Count; i++)
        {
            spawnedObjects.Add(Instantiate(objectPrefabs[i], objectSpawnPoints[i]));
            spawnedObjects[i].SetActive(false);
        }

        //hide canvas
        foreach (CanvasGroup panel in meltingCanvas.GetComponentsInChildren<CanvasGroup>())
        {
            panel.alpha = 0;
            panel.interactable = false;
            panel.blocksRaycasts = false;
        }

        solidus = GetComponent<SolidusController>();

    }

    

    public void BeginMeltingLevelSetUp()
    {
        StartCoroutine(SetUpMeltingTable());
    }

    public void SpawnTable()
    {
        rendererTableLeft = tableLeft.GetComponentInChildren<SkinnedMeshRenderer>();
        rendererTableRight = tableRight.GetComponentInChildren<SkinnedMeshRenderer>();
        skinnedMeshLeft = tableLeft.GetComponentInChildren<SkinnedMeshRenderer>().sharedMesh;

        for (int i = 0; i < skinnedMeshLeft.blendShapeCount; i++)
        {
            rendererTableLeft.SetBlendShapeWeight(i, blendWeight);
            rendererTableRight.SetBlendShapeWeight(i, blendWeight);
        }

    }

    private IEnumerator SetUpMeltingTable()
    {
        //wait until level reached
        while (moveElevator.destinationDepth != 170f || moveElevator.currentDepth < 168f || moveElevator.currentDepth > 172f)
        {
            yield return null;
        }

        yield return new WaitForSeconds(pauseBeforePanelRetract);
        
        //Retract Panel
        panelAngleNEW = panelNEW.transform.localEulerAngles.x;
        while (panelAngleNEW > 0.1)
        {
            panelNEW.transform.RotateAround(panelPivotNEW.position, rotateAxisNEW, -rotateSpeedNEW * Time.deltaTime);
            panelAngleNEW -= rotateSpeedNEW * Time.deltaTime;

            yield return null;
        }

        yield return new WaitForSeconds(pauseBeforeTableBuild);

        SpawnTable();

              
        //build table part 1

        while (rendererTableLeft.GetBlendShapeWeight(0) < 100)
        {
            rendererTableLeft.SetBlendShapeWeight(0, blendWeight);
            rendererTableRight.SetBlendShapeWeight(0, blendWeight);
            blendWeight += buildSpeed * Time.deltaTime;

            yield return null;
        }

        //Reset Blend Weight
        blendWeight = 0f;

        yield return new WaitForSeconds(pauseBetweenTableSections);

        //build table part 2

        while (rendererTableLeft.GetBlendShapeWeight(1) < 100)
        {
            rendererTableLeft.SetBlendShapeWeight(1, blendWeight);
            rendererTableRight.SetBlendShapeWeight(1, blendWeight);
            blendWeight += buildSpeed * Time.deltaTime;

            yield return null;
        }

        //Reset Blend Weight
        blendWeight = 0f;

        yield return new WaitForSeconds(pauseBetweenTableSections);

        //build table part 3

        while (rendererTableLeft.GetBlendShapeWeight(2) < 100)
        {
            rendererTableLeft.SetBlendShapeWeight(2, blendWeight);
            rendererTableRight.SetBlendShapeWeight(2, blendWeight);
            blendWeight += buildSpeed * Time.deltaTime;

            yield return null;
        }

        //Reset Blend Weight
        blendWeight = 0f;

        yield return new WaitForSeconds(pauseBetweenTableSections);

        //build table part 4

        while (rendererTableLeft.GetBlendShapeWeight(3) < 100)
        {
            rendererTableLeft.SetBlendShapeWeight(3, blendWeight);
            rendererTableRight.SetBlendShapeWeight(3, blendWeight);
            blendWeight += buildSpeed * Time.deltaTime;

            yield return null;
        }

        //Reset Blend Weight
        blendWeight = 0f;

        yield return new WaitForSeconds(pauseBeforeSpawn);


        //spawn items and display canvas

        for (int i = 0; i < spawnedObjects.Count; i++)
        {
            spawnedObjects[i].SetActive(true);
        }

        yield return new WaitForSeconds(pauseBeforePanel);

        foreach (CanvasGroup panel in meltingCanvas.GetComponentsInChildren<CanvasGroup>())
        {
            panel.DOFade(1f, 1f);
            panel.blocksRaycasts = true;
        }

        solidus.setSolidus = true;

    }
}
