using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Buss : MonoBehaviour
{
    public int Capacity;
    [SerializeField] public int MaxCapacity;
    public bool IsAvailable;
    public int BussIndex;
    public ObjectColor BussColor;
}