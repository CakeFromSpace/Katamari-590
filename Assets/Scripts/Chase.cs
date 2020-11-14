using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : MonoBehaviour
{
    public GameObject target;
    public GameObject katamari;
    public float height;
    public float trailingdistance;
    public float pandown;
    public float _trail;
    public float _height;
    Movement targetinfo;
    void Start()
    {
        targetinfo = target.GetComponent<Movement>();
        _trail = trailingdistance;
        _height = height;
    }

    // Update is called once per frame
    void Update()
    {

        
        transform.rotation = Quaternion.LookRotation(targetinfo.forward);
        transform.Rotate(new Vector3(pandown,0,0));
        _trail = trailingdistance * target.transform.localScale.x * katamari.transform.localScale.x;
        _height = height * target.transform.localScale.x * katamari.transform.localScale.x;
        Vector3 targetpos = target.transform.position;
        targetpos -= _trail * targetinfo.forward;
        targetpos.y += _height;
        transform.position = targetpos;
    }
}
