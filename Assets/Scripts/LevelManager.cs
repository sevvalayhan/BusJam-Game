using System;
using System.Collections.Generic;
using UnityEngine;
public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    [NonSerialized] public LevelAssetCreate levelAsset;
    public GameState gameState;
    [SerializeField] PathManager pathManager;
    [SerializeField] BussController bussController;
    public GridManager gridManager;
    [NonSerialized] public Dictionary<Vector2Int, GridCell> cellDic = new Dictionary<Vector2Int, GridCell>();
    [NonSerialized] public Dictionary<Vector2Int, GridCell> emptyGridDic = new Dictionary<Vector2Int, GridCell>();
    [NonSerialized] public Dictionary<Vector2Int, GridCell> StallCellDict = new Dictionary<Vector2Int, GridCell>();
    [NonSerialized] public Dictionary<int, Buss> BussDictionary = new Dictionary<int, Buss>();
    public bool editMode = false;
    [Header("grid Cell Component")]
    public GridCell startingCell;
    public GridCell endingCell;
    RaycastHit raycastHit;
    int layerMask = (1 << 6);

    private void Awake()
    {
        instance = this;
        levelAsset = Resources.Load<LevelAssetCreate>("Assets/Scripts/Scriptables/LevelAsset");
        gameState = GameState.Ready;
    }
    private void Start()
    {
        if (editMode)
        {
            gridManager.SetInitialValues();
        }
        else
        {
            CreateLevel();
        }
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && gameState == GameState.Ready && gridManager != null)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out raycastHit, Mathf.Infinity, layerMask))
            {
                GridCell _rayGrid = raycastHit.transform.GetComponent<GridCell>();
                if (_rayGrid != null && _rayGrid.gridCellColor != ObjectColor.Null && startingCell == null)
                {
                    startingCell = _rayGrid;
                }
                else if (bussController.CurrentBuss.BussColor == startingCell.gridCellColor)
                {
                    endingCell = gridManager.BussStall;
                }
                else
                {
                    GridCell stall = gridManager.CurrentStall();
                    if (stall != null && startingCell != null)
                    {
                        stall.IsAvailable = false;
                        endingCell = stall;
                        SendStickmanToTargetCell();
                        Debug.Log(stall.gridCellColor);
                    }
                    else
                    {
                        Debug.Log("Game Over!");
                    }
                }
                Debug.Log(endingCell);
            }
        }
    }
    void SendStickmanToTargetCell()
    {
        Debug.Log("Metot çalýþtý.");
        pathManager.CreateAvailablePath(startingCell, endingCell);
        StickmanController goingStickman = startingCell.includingStickman;
        if (goingStickman != null && goingStickman.path.Count > 0)
        {
            goingStickman.GoAtPath();
        }
        ResetTurn();
    }
    void CreateLevel()
    {
        if (GameManager.Level <= levelAsset.levelPrefabs.Count)
        {
            GameObject createdgridObj = Instantiate(levelAsset.levelPrefabs[GameManager.Level - 1]);
            gridManager = createdgridObj.GetComponent<GridManager>();
            gridManager.SetInitialValues();
        }
        else
        {
            if (GameManager.RandomLevel == 0)
            {
                List<int> nextLevelList = new List<int>();
                for (int i = 0; i < levelAsset.levelPrefabs.Count; i++)
                {
                    nextLevelList.Add(i);
                }
                nextLevelList.Remove(GameManager.PreviousLevel);
                int random = UnityEngine.Random.Range(27, nextLevelList.Count);
                GameManager.RandomLevel = nextLevelList[random]; ;
            }
            GameObject createdgridObj = Instantiate(levelAsset.levelPrefabs[GameManager.RandomLevel]);
            gridManager = createdgridObj.GetComponent<GridManager>();
            gridManager.SetInitialValues();
        }
    }
    public void ResetTurn()
    {
        Debug.Log("TURN RESETLENDI");
        gameState = GameState.Ready;
        startingCell = null;
        endingCell = null;
    }
}
