using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BussStall : MonoBehaviour
{
    [SerializeField] public Vector3 BusStallPos;
    public bool IsAvailable;
    public static BussStall Instance;
    private void Start()
    {
       BusStallPos = this.transform.position;
       IsAvailable = true;
    }
}
