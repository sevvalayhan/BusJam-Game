using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public static class Extention 
{
    public static void MakeMaterialInstance( this GameObject _obj)
    {
        MeshRenderer meshRenderer= _obj.GetComponent<MeshRenderer>();
        Material material= meshRenderer.material;
        meshRenderer.material = material;
    }
}
