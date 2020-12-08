using System.Collections;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using UnityEngine;

//Author Joseph Yunis
public class Stick : MonoBehaviour
{
    public float size;
    Rigidbody rd;
    Collider coll;
    public GameObject katamari;
    public GameObject constellation;
    // Start is called before the first frame update
    void Start()
    {
        rd = gameObject.GetComponent<Rigidbody>();
        coll = gameObject.GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.gameObject.tag== "sticky")
        {
            Vector3 loc = Vector3.Normalize(katamari.transform.position - transform.position) * katamari.GetComponent<SphereCollider>().radius*-1;
            //Debug.Log(loc.magnitude);
            transform.position = katamari.transform.position + loc;//  transform.TransformPoint(loc);
            transform.parent = constellation.transform;
            gameObject.tag = "sticky";
            SphereCollider s = katamari.gameObject.GetComponent<SphereCollider>();
            s.radius += size*2;
            Destroy(rd);
        }
    }
    //private void OnCollisionEnter(Collision collision)
    //{
    //   if(collision.collider.gameObject.tag == "sticky" || (collision.collider.gameObject.tag == "pickup" &&collision.collider.gameObject.transform.parent))
    //    {
    //        Debug.Log(name + collision.collider.gameObject.name);
    //
    //        Vector3 loc = Vector3.Normalize(player.transform.position - transform.position)*player.GetComponent<SphereCollider>().radius;
    //
    //        Debug.Log(loc);
    //        
    //        
    //        transform.position = transform.TransformPoint(loc);
    //        transform.parent = player.transform;
    //gameObject.tag = "sticky";
    //        SphereCollider s = player.gameObject.GetComponent<SphereCollider>();
    //        s.radius += size;
    //        Destroy(rd);
    //    }
    //    if(collision.collider.gameObject.tag == "pickup")
    //    {
    //        Physics.IgnoreCollision(coll, collision.collider);
    //    }
    //}
}
