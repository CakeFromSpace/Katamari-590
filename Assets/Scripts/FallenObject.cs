using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallenObject : MonoBehaviour
{
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if((Vector3.zero - transform.position).magnitude > 40000)
        {
            foreach(Transform child in transform)
            {
                Destroy(child.gameObject);
            }
            Destroy(this);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if(rb != null)
        {
            Destroy(GetComponentInChildren<ParticleSystem>());
            Destroy(GetComponent<Rigidbody>());
            gameObject.layer = 0;
            gameObject.tag = "pickup";
            Destroy(GetComponent<FallenObject>());
        }
    }
}
