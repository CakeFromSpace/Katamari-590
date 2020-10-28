using System.Collections;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using UnityEngine;

//Author Joseph Yunis
public class PlayerStick : MonoBehaviour
{
    Rigidbody rd;
    Collider coll;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject other = collision.collider.gameObject;

        if(collision.collider.gameObject.tag == "pickup")
        {

            Debug.Log(name + other.name);

            Vector3 loc = Vector3.Normalize(transform.position - other.transform.position)*this.gameObject.GetComponent<SphereCollider>().radius;

            Debug.Log(loc);
            
            SphereCollider s = this.gameObject.GetComponent<SphereCollider>();
            MeshCollider m = other.gameObject.GetComponent<MeshCollider>();
            if(Vector3.Magnitude(s.bounds.size) > Vector3.Magnitude(m.bounds.size))
            {
                other.transform.position = transform.TransformPoint(loc);
                other.transform.parent = transform;
                other.tag = "sticky";
                m.convex = true;
            }

            s.radius += Vector3.Magnitude(m.bounds.size) / 1000;

        }
    }
}
