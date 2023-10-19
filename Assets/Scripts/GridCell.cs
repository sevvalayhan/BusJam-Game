using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GridCell : MonoBehaviour
{
    public Vector2Int cellCoord;
    public ObjectColor gridCellColor;
    public GridCellType gridCellType;
    public StickmanController includingStickman;
    public int visited = 0;
    public bool IsAvailable = true;
    public void ArrangeStickman(ObjectColor _cellColor )
    {
        if (LevelManager.instance != null)
        {
            LevelAssetCreate levelAsset = LevelManager.instance.levelAsset;
            GameObject createdStickmanObj = Instantiate(levelAsset.stickmanPrefabs[(int)_cellColor]); 
            StickmanController stickmanController = createdStickmanObj.GetComponent<StickmanController>();
            createdStickmanObj.MakeMaterialInstance();
            createdStickmanObj.transform.SetParent(transform);
            createdStickmanObj.transform.localPosition = new Vector3(0,1,0);
            includingStickman = stickmanController;
            stickmanController.gridCellColor = _cellColor;
        }
    }
}
