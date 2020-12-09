using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Written by Joe
//Enable and disable AI depending on if the player is close or not
public class AISwitch : MonoBehaviour
{
    AI aiscript;
    Animator anim;
    void Start()
    {
        transform.localPosition = new Vector3(0,0,0);
        SphereCollider playerdetection;
        playerdetection = this.gameObject.AddComponent<SphereCollider>();
        playerdetection.radius = 1000;
        playerdetection.isTrigger = true;
        aiscript = GetComponentInParent<AI>();
        aiscript.enabled = false;

        anim = GetComponentInParent<Animator>();
        if(anim!=null)anim.enabled = false;

        // added by judge, prevent AI from detecting this object
        gameObject.layer = 2;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "katamari")
        {
            //Debug.Log("entered");
            aiscript.enabled = true;
            if (anim != null) anim.enabled = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "katamari")
        {
            //Debug.Log("Exited");
            aiscript.enabled = false;
            if (anim != null) anim.enabled = false;
        }
    }


}
