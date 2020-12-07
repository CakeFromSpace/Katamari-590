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
