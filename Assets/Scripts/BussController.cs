using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
        if (IsBussFull())
        {
            BussMove(new Vector3(BussStall.BusStallPos.x + 30, BussStall.BusStallPos.y, BussStall.BusStallPos.z));
            BussStall.IsAvailable = true;
        }
    }
    private void currentBuss()
    {
        foreach (var buss in BussList)
        {
            if (buss.IsAvailable)
            {
                if (BussStall.IsAvailable)
                {
                    BussStall.IsAvailable = false;
                    CurrentBuss = buss;
                    BussMove(BussStall.BusStallPos);
                }
            }
        }
    }
    private bool IsBussFull()
    {
        if (CurrentBuss.Capacity == CurrentBuss.MaxCapacity)
        {
            Debug.Log("Buss Is Full");
            CurrentBuss.IsAvailable = false;
            return true;
        }
        else
        {
            return false;
        }
    }
    public void BussMove(Vector3 bussDirection)
    {
        CurrentBuss.transform.DOMove(bussDirection, moveDuration);        
    }
}