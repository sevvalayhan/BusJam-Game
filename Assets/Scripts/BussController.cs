using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BussController : MonoBehaviour
{
    public List<Buss> BussList = new List<Buss>();
    public Buss CurrentBuss;
    [SerializeField] public BussStall BussStall;
    public float moveDuration = 2f;
    //public void SetInitialValues()
    //{
    //    foreach (var buss in BussList)
    //    {
    //        LevelManager.instance.BussDictionary.Add(buss.BussIndex,buss);
    //    }
    //}   
    void Update()
    {
        currentBuss();
    }
    private void currentBuss()
    {
        foreach(var buss in BussList)
        {
            if (buss.IsAvailable)
            {        
                if (BussStall.IsAvailable)
                {
                    CurrentBuss = buss;
                    BussMove();
                    buss.IsAvailable = false;
                    BussStall.IsAvailable = false;
                    break;
                }                
            }
        }        
    }    
    public void BussMove()
    {
        CurrentBuss.transform.DOMove(BussStall.BusStallPos, moveDuration);
        //.OnStepComplete(() =>
        //{
        //    if (CurrentBuss.Capacity.Equals(CurrentBuss.MaxCapacity))
        //    {
        //        CurrentBuss.transform.DOMove(new Vector3(BussStall.x + 200, BussStall.y, BussStall.z),moveDuration);
        //    }
        //});
    }
}