using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Written by Joe
//Enable and disable AI depending on if the player is close or not
public class AISwitch : MonoBehaviour
{
    HumanAI aiscript;
    void Start()
    {
        transform.localPosition = new Vector3(0,0,0);
        SphereCollider playerdetection;
        playerdetection = this.gameObject.AddComponent<SphereCollider>();
        playerdetection.radius = 1000;
        playerdetection.isTrigger = true;
        aiscript = GetComponentInParent<HumanAI>();
        aiscript.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("entered");
            aiscript.enabled = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Exited");
            aiscript.enabled = false;
        }
    }


}
