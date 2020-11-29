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
    NewInputSystemControls targetnewcontrol;
    string movetype;
    void Start()
    {
        if (target.GetComponent<Movement>().enabled)
        {
            targetinfo = target.GetComponent<Movement>();
            movetype = "normal";
        }
        else if (target.GetComponent<NewInputSystemControls>().enabled)
        {
            targetnewcontrol = target.GetComponent<NewInputSystemControls>();
            movetype = "newcontrol";
        }
        else
        {
            Debug.LogError("No movement script enabled on player!");
        }
        _trail = trailingdistance;
        _height = height;
    }

    // Update is called once per frame
    void Update()
    {
        _trail = trailingdistance * target.transform.localScale.x * katamari.transform.localScale.x;
        _height = height * target.transform.localScale.x * katamari.transform.localScale.x;
        Vector3 targetpos = target.transform.position;
        
        targetpos.y += _height;
        
        if (movetype == "normal")
        {
            transform.rotation = Quaternion.LookRotation(targetinfo.forward);
            targetpos -= _trail * targetinfo.forward;
        }
        else if(movetype == "newcontrol")
        {
            transform.rotation = Quaternion.LookRotation(targetnewcontrol.forward);
            targetpos -= _trail * targetnewcontrol.forward;
        }
        transform.position = targetpos;
        transform.Rotate(new Vector3(pandown,0,0));
        
    }
}
