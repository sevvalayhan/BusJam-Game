using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.Experimental.GlobalIllumination;

public class StickmanController : MonoBehaviour
{
    public ObjectColor gridCellColor;
    public List<GridCell> path = new List<GridCell>();
    Tween pathTween;
    public void GoAtPath()
    {
        float movementUnitDuration = 0.3f;
        int pathCount = path.Count;
        if (pathCount > 0)
        {
            pathTween?.Kill();
            Vector3[] pointListV3 = new Vector3[pathCount];
            for (int i = 0; i < pathCount; i++)
            {
                pointListV3[pathCount - 1 - i] = path[i].transform.position + Vector3.up; 
            }
            GridCell starting = path[pathCount - 1];
            GridCell target = path[0];
            LevelManager.instance.emptyGridDic.Add(starting.cellCoord, starting);
            LevelManager.instance.emptyGridDic.Remove(target.cellCoord);
            
            starting.includingStickman = null;
            target.gridCellColor = starting.gridCellColor;
            starting.gridCellColor = ObjectColor.Null;
            target.includingStickman = this;
            target.includingStickman.transform.SetParent(target.transform);

            pathTween = transform.DOPath(pointListV3, movementUnitDuration * path.Count, PathType.Linear).SetEase(Ease.Linear).OnWaypointChange(x => AnotherMethodERcan(x, path)).OnStepComplete(() =>
            {
                //includingBall.transform.SetParent(_target.transform);
                //includingBall.transform.localPosition = Vector3.zero;
                //_target.DeselectedCell();

                //ResetSelectedAndTargetCell();
                //MatchControlAfterInput(_target);
                //lineRenderer.enabled = false;
            });
        }
    }
    void AnotherMethodERcan(int waypointIndex, List<GridCell> _path)
    {
        if (waypointIndex != 0 && waypointIndex <= _path.Count)
        {
            Debug.Log("waypointIndex: " + waypointIndex);
        }
    }
}
