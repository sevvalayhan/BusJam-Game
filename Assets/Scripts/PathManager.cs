using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Unity.VisualScripting;                        
public class PathManager : MonoBehaviour
{
    public List<GridCell> tempList = new List<GridCell>();
    public void CreateAvailablePath(GridCell _startCell, GridCell _endingCell)
    {
        Dictionary<Vector2Int, GridCell> tempGridDic = new Dictionary<Vector2Int, GridCell>();        
        _startCell.visited = 0;
        tempGridDic.Add(_startCell.cellCoord, _startCell);        
        if (LevelManager.instance.emptyGridDic.Count > 0)
        {
            tempGridDic.AddRange(LevelManager.instance.emptyGridDic);
            tempGridDic.Add(_endingCell.cellCoord, _endingCell);
            foreach (var emptyDicPart in LevelManager.instance.emptyGridDic)
            {
                GridCell _emptyGrid = emptyDicPart.Value;
                //tempGridDic.Add(_emptyGrid.cellCoord, _emptyGrid);
                _emptyGrid.visited = -1;
            }
        }
        Debug.Log("tempGridDic Count: " + tempGridDic.Count);
        for (int step = 1; step < tempGridDic.Count; step++)
        {
            foreach (var obj in tempGridDic)
            {
                if (obj.Value.visited == (step - 1))
                {
                    Debug.Log("visited"+(step-1));
                    TestFourDirection(obj.Key.x, obj.Key.y, step, tempGridDic);
                }
            }
        }
        SetPath(tempGridDic, _startCell, _endingCell);
        tempGridDic.Clear();
    }
    private void TestFourDirection(int x, int y, int step, Dictionary<Vector2Int, GridCell> _tempcoridorWayGameDic)
    {
        // 1 up, 2 right, 3 down, 4 left

        if (TestDirection(x, y, -1, 1, _tempcoridorWayGameDic))
            SetVisited(x, y + 1, step, _tempcoridorWayGameDic);

        if (TestDirection(x, y, -1, 2, _tempcoridorWayGameDic))
            SetVisited(x + 1, y, step, _tempcoridorWayGameDic);

        if (TestDirection(x, y, -1, 3, _tempcoridorWayGameDic))
            SetVisited(x, y - 1, step, _tempcoridorWayGameDic);

        if (TestDirection(x, y, -1, 4, _tempcoridorWayGameDic))
            SetVisited(x - 1, y, step, _tempcoridorWayGameDic);
    }

    private bool TestDirection(int x, int y, int step, int direction, Dictionary<Vector2Int, GridCell> _tempcoridorWayGameDic)
    {
        // 1 up, 2 right, 3 down, 4 left
        switch (direction)
        {
            case 4:
                if (_tempcoridorWayGameDic.ContainsKey(new Vector2Int(x - 1, y)) && _tempcoridorWayGameDic[new Vector2Int(x - 1, y)].visited == step)
                {
                    return true;
                }
                else
                    return false;

            case 3:
                if (_tempcoridorWayGameDic.ContainsKey(new Vector2Int(x, y - 1)) && _tempcoridorWayGameDic[new Vector2Int(x, y - 1)].visited == step)
                {
                    return true;
                }
                else
                    return false;

            case 2:
                if (_tempcoridorWayGameDic.ContainsKey(new Vector2Int(x + 1, y)) && _tempcoridorWayGameDic[new Vector2Int(x + 1, y)].visited == step)
                {
                    return true;
                }
                else
                    return false;

            case 1:
                if (_tempcoridorWayGameDic.ContainsKey(new Vector2Int(x, y + 1)) && _tempcoridorWayGameDic[new Vector2Int(x, y + 1)].visited == step)
                {
                    return true;
                }
                else
                    return false;
        }
        return false;
    }
    private void SetVisited(int x, int y, int step, Dictionary<Vector2Int, GridCell> _tempcoridorWayGameDic)
    {
        if (_tempcoridorWayGameDic.ContainsKey(new Vector2Int(x, y)))
        {
            _tempcoridorWayGameDic[new Vector2Int(x, y)].visited = step;
        }
    }
    void SetPath(Dictionary<Vector2Int, GridCell> _tempcoridorWayGameDic, GridCell starting, GridCell target)
    {
        int step;
        int x = target.cellCoord.x;
        int y = target.cellCoord.y;

        StickmanController thisStickman = starting.includingStickman;
        thisStickman.path.Clear();

        /**/
        if (_tempcoridorWayGameDic.ContainsKey(new Vector2Int(target.cellCoord.x, target.cellCoord.y)) &&
            _tempcoridorWayGameDic[new Vector2Int(target.cellCoord.x, target.cellCoord.y)].visited > 0)
        {
            Debug.Log("pathe biþey eklendi");
            thisStickman.path.Add(target);
            step = _tempcoridorWayGameDic[new Vector2Int(x, y)].visited - 1;
        }
        else
        {
            Debug.Log("Stickman target celle gidemiyor");
            //LevelManager.instance.ResetTurn();
            return;
        }
        for (int i = step; step > -1; step--)
        {
            //Debug.Log("kaç kez döndü SetPath içi for");
            if (TestDirection(x, y, step, 1, _tempcoridorWayGameDic))
            {
                tempList.Add(LevelManager.instance.cellDic[new Vector2Int(x, y + 1)]);
            }
            if (TestDirection(x, y, step, 2, _tempcoridorWayGameDic))
            {
                tempList.Add(LevelManager.instance.cellDic[new Vector2Int(x + 1, y)]);
            }
            if (TestDirection(x, y, step, 3, _tempcoridorWayGameDic))
            {
                tempList.Add(LevelManager.instance.cellDic[new Vector2Int(x, y - 1)]);
            }
            if (TestDirection(x, y, step, 4, _tempcoridorWayGameDic))
            {
                tempList.Add(LevelManager.instance.cellDic[new Vector2Int(x - 1, y)]);
            }

            GridCell tempObjSeat = FindClosest(_tempcoridorWayGameDic[new Vector2Int(target.cellCoord.x, target.cellCoord.y)].transform, tempList);

            if (LevelManager.instance.cellDic.ContainsKey(tempObjSeat.cellCoord))
            {
                thisStickman.path.Add(LevelManager.instance.cellDic[tempObjSeat.cellCoord]);
            }
            x = tempObjSeat.cellCoord.x;
            y = tempObjSeat.cellCoord.y;
            tempList.Clear();
        }
    }
    //-------------------------------------
    GridCell FindClosest(Transform targetLocation, List<GridCell> list)
    {
        float currentDistance = 3 * 100000000; //en uzun köþegen
        int indexNumber = 0;
        for (int i = 0; i < list.Count; i++)
        {
            if (Vector3.Distance(targetLocation.position, list[i].transform.position) < currentDistance)
            {
                currentDistance = Vector3.Distance(targetLocation.position, list[i].transform.position);
                indexNumber = i;
            }
        }
        return list[indexNumber];
    }
}