using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : MonoBehaviour
{
    public GameObject target;
    public float height;
    public float trailingdistance;
    public float pandown;
    Movement targetinfo;
    void Start()
    {
        targetinfo = target.GetComponent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.LookRotation(targetinfo.forward);
        transform.Rotate(new Vector3(pandown,0,0));

        Vector3 targetpos = target.transform.position;
        targetpos -= trailingdistance * targetinfo.forward;
        targetpos.y += height;
        transform.position = targetpos;
    }
}
