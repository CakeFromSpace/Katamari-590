using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadUnload : MonoBehaviour
{
    public List<MeshRenderer> rend;
    void Start()
    {
        SphereCollider playerdetection;
        playerdetection = this.gameObject.AddComponent<SphereCollider>();
        //playerdetection.radius = transform.parent.GetChild(0).localScale.x*2000;
        playerdetection.radius = 5000;
        playerdetection.isTrigger = true;

        rend = new List<MeshRenderer>(transform.parent.gameObject.GetComponentsInChildren<MeshRenderer>());
        foreach(Renderer r in rend)
        {
            r.enabled = false;
        }

    }

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            foreach (Renderer r in rend)
            {
                if(r != null)
                {
                    r.enabled = true;
                }
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            foreach (Renderer r in rend)
            {
                if(r != null)
                {
                    r.enabled = false;
                }
            }
        }
    }
}
