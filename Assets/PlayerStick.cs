using System.Collections;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using UnityEngine;

//Author Joseph Yunis
public class PlayerStick : MonoBehaviour
{
    GameObject katamari;
    GameObject constellation;
    public float growrate;
    // Start is called before the first frame update
    void Start()
    {
        katamari = transform.Find("katamari").gameObject;
        constellation = transform.Find("Object Constellation").gameObject;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject other = collision.collider.gameObject;

        if (collision.collider.gameObject.tag == "pickup")
        {

            //Debug.Log(name + other.name);

            //Vector3 loc = Vector3.Normalize(transform.position - other.transform.position) * katamari.GetComponent<SphereCollider>().radius * -1;
            Vector3 loc = (transform.position - other.transform.position) * -1;
            //Debug.Log();

            SphereCollider s = katamari.gameObject.GetComponent<SphereCollider>();
            //Debug.Log(Mathf.Pow(s.radius, 3) * 4 / 3 * Mathf.PI);
            BoxCollider m = other.gameObject.GetComponent<BoxCollider>();
            //Debug.Log(m.bounds.size.x * m.bounds.size.y * m.bounds.size.z * m.transform.localScale.x * m.transform.localScale.y * m.transform.localScale.z);
            Debug.Log(m.size.x * m.transform.lossyScale.x+" "+m.size.y * m.transform.lossyScale.y+" "+ m.size.z * m.transform.lossyScale.z);
            Debug.Log(katamari.transform.lossyScale.x);
            float sizeofobject = m.bounds.size.x * m.bounds.size.y * m.bounds.size.z * m.transform.localScale.x * m.transform.localScale.y * m.transform.localScale.z;
            if (Mathf.Pow(s.radius,3)*4/3*Mathf.PI > sizeofobject)
            {
                
                other.transform.position = transform.position + loc;
                other.transform.parent = constellation.transform;
                
                if(m.size.x*m.transform.localScale.x> katamari.transform.lossyScale.x || m.size.y * m.transform.localScale.y > katamari.transform.lossyScale.x|| m.size.z * m.transform.localScale.z >  katamari.transform.lossyScale.x )
                {
                    other.layer = 11;
                }
                else
                {
                    other.layer = 8;
                }
                //s.radius += Vector3.Magnitude(m.bounds.size) * growrate;
                katamari.transform.localScale += new Vector3(sizeofobject,sizeofobject,sizeofobject)*growrate;
                Rigidbody rd = other.GetComponent<Rigidbody>();
                Destroy(rd);
            }

            

        }
    }
}