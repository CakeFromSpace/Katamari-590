using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectLoadingUnloading : MonoBehaviour
{
    private void Awake()
    {
        GameObject s = new GameObject("Loader");
        s.layer = 2;
        s.tag = "loader";
        s.AddComponent<LoadUnload>();
        s.transform.parent = transform;
    }
}
