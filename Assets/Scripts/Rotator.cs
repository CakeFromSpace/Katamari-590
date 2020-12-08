using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Author Joe
public class Rotator : MonoBehaviour
{
    public float rotatespeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(transform.position, transform.up, Time.deltaTime * rotatespeed);
    }
}
