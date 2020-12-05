using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectLoadingUnloading : MonoBehaviour
{
    private void Awake()
    {
        GameObject s = new GameObject("Loader");
        s.AddComponent<LoadUnload>();
        s.transform.parent = transform;
    }
}
