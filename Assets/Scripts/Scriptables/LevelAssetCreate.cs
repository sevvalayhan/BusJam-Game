using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
[CreateAssetMenu(fileName = "LevelAsset", menuName = "ScriptableObjects/LevelAssetCreate", order = 1)]
public class LevelAssetCreate : ScriptableObject
{
    [SerializeField] public List<GameObject> levelPrefabs = new List<GameObject>();
    [SerializeField] public List<GameObject> stickmanPrefabs;
}