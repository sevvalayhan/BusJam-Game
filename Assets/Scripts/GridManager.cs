using System.Collections.Generic;
using UnityEngine;
public class GridManager : MonoBehaviour
{
    public List<GridCell> cellInGridList= new List<GridCell>();
    public List<GridCell> StallCellList = new List<GridCell>();
    public GridCell BussStall;
    public void SetInitialValues()
    {
        //LevelManager.instance.cellDic.Add(BussStall.cellCoord,BussStall);
        int cellInGridListCount = cellInGridList.Count;
        for (int i = 0; i < cellInGridListCount; i++)
        {
            GridCell thisGridCell = cellInGridList[i];
            LevelManager.instance.cellDic.Add(thisGridCell.cellCoord, thisGridCell);
            thisGridCell.name = "Cell" + thisGridCell.cellCoord.x + "," + thisGridCell.cellCoord.y + ")";

            if (thisGridCell.gridCellColor != ObjectColor.Null)
            {
                thisGridCell.ArrangeStickman(thisGridCell.gridCellColor);
            }
            else if (thisGridCell.gridCellColor == ObjectColor.Null && thisGridCell.gridCellType == GridCellType.Normal)
            {
                LevelManager.instance.emptyGridDic.Add(thisGridCell.cellCoord, thisGridCell);
            }
        }
        foreach (GridCell stallCell in StallCellList)
        {
            stallCell.visited = 0;
            LevelManager.instance.StallCellDict.Add(stallCell.cellCoord, stallCell);
        }       
        Debug.Log("cellDic Count: " + LevelManager.instance.cellDic.Count);
        Debug.Log("emptyDic Count: " + LevelManager.instance.emptyGridDic.Count);
    }
    public GridCell CurrentStall()
    {
        Queue<GridCell> gridCells = new Queue<GridCell>();
        foreach (var stallCell in StallCellList)
        {
            gridCells.Enqueue(stallCell);
        }
        return gridCells.Dequeue();        
    }
}