using System.Collections;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using UnityEngine;
using UnityEngine.UI;
using System;

//Author Joseph Yunis
public class PlayerStick : MonoBehaviour
{
    GameObject katamari;
    GameObject constellation;
    public float growrate;
    public Text RadiusUIText;
    public Text PickupUIText;
    public GameObject UIPickup;
    public float attachablemultiplier;
    private Rigidbody rb;
    private float vel_threshold;
    // Start is called before the first frame update
    void Start()
    {
        katamari = transform.Find("katamari").gameObject;
        constellation = transform.Find("Object Constellation").gameObject;
        rb = GetComponent<Rigidbody>();
        vel_threshold = GetComponent<Movement>().maxvelocity / 2;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider collision)
    {
        GameObject other = collision.GetComponent<Collider>().gameObject;

        if (collision.GetComponent<Collider>().gameObject.tag == "pickup" && !collision.isTrigger)
        {

            //Debug.Log(name + other.name);

            //Vector3 loc = Vector3.Normalize(transform.position - other.transform.position) * katamari.GetComponent<SphereCollider>().radius * -1;
            Vector3 loc = (transform.position - other.transform.position) * -1;
            //Debug.Log();

            SphereCollider s = katamari.gameObject.GetComponent<SphereCollider>();
            //Debug.Log(Mathf.Pow(s.radius, 3) * 4 / 3 * Mathf.PI);
            Collider m = other.gameObject.GetComponent<Collider>();
            //Debug.Log(m.bounds.size.x * m.bounds.size.y * m.bounds.size.z * m.transform.localScale.x * m.transform.localScale.y * m.transform.localScale.z);
            
            
            // changed in by judge 11/14 to fix mesh collider issues
            float sizeofobject = m.bounds.size.magnitude;
            float sizeofplayer = s.bounds.size.magnitude;
            //Debug.Log(sizeofobject + " " + sizeofplayer);
            if (sizeofplayer * attachablemultiplier > sizeofobject)
            {
                MeshCollider mesh = other.GetComponentInChildren<MeshCollider>();
                if(mesh != null)
                {
                    mesh.convex = true;
                }


                
                //if(m.size.x*m.transform.localScale.x> katamari.transform.lossyScale.x || m.size.y * m.transform.localScale.y > katamari.transform.lossyScale.x|| m.size.z * m.transform.localScale.z >  katamari.transform.lossyScale.x )
                if(m.bounds.size.x> katamari.transform.lossyScale.x || m.bounds.size.y> katamari.transform.lossyScale.x|| m.bounds.size.z >  katamari.transform.lossyScale.x )
                {
                    other.layer = 11;
                }
                else
                {
                    other.layer = 8;
                    Destroy(m);//get rid of collider so that rigidbody doesnt get lopsided
                }

                // hi this is judge I added this in to make the AI stop moving once you get them
                other.tag = "sticky";
                
                Debug.Log(new Vector3(sizeofobject,sizeofobject,sizeofobject)*growrate);
                katamari.transform.localScale += new Vector3(sizeofobject,sizeofobject,sizeofobject)*growrate;
                RadiusUIText.GetComponent<Text>().text = (System.Math.Round(katamari.transform.localScale.x,2) * 10)+" CM";
                

                foreach (Transform child in UIPickup.transform)
                {
                    GameObject.Destroy(child.gameObject);
                }

                GameObject copy = Instantiate(other);
                Destroy(copy.GetComponent<Rigidbody>());
                
                
                copy.transform.parent = UIPickup.transform;
                copy.transform.localPosition = new Vector3(0, 0, 0);

                
                // judge added 11/30, to scale the items being picked up by camera -- not perfect however.
                Vector3 size = copy.GetComponent<Collider>().bounds.size;
                copy.transform.localScale = copy.transform.localScale / Mathf.Max(size.x, size.y, size.z);
                if(copy.GetComponent<AI>() != null)
                {
                    copy.GetComponent<AI>().enabled = false;
                }
                copy.layer = 13;
                PickupUIText.GetComponent<Text>().text = other.name;
                
                // changed by judge 12/1 ... added this condition so small objects will stop being rendered at large sizes, and moved it down here in order to keep the object camera working
                if(sizeofplayer * attachablemultiplier < 5 * sizeofobject)
                {
                    Debug.Log("pickup");
                    Debug.Log(sizeofplayer);
                    Debug.Log(sizeofobject);
                    other.transform.position = transform.position + loc;
                    other.transform.parent = constellation.transform;
                }
                else
                {
                    other.SetActive(false);
                }

                Rigidbody rd = other.GetComponent<Rigidbody>();
                Destroy(rd);
            }

            

        }
    }
}