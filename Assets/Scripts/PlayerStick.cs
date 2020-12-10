using System.Collections;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using UnityEngine;
using UnityEngine.UI;
using System;

//Author Joe w/ several edits by Judge
public class PlayerStick : MonoBehaviour
{
    public List<GameObject> particles;
    GameObject katamari;
    GameObject constellation;
    public GameObject fallen_objects;
    public float growrate;
    public Text RadiusUIText;
    public Text PickupUIText;
    public GameObject UIPickup;
    public float attachablemultiplier;
    public float remove_time;
    private Rigidbody rb;
    private float vel_threshold;
    private float remove_timer;
    private bool recently_removed;

    private float volume_cache;

    private float calc_timer;
    // Start is called before the first frame update
    void Start() 
    {
        katamari = transform.Find("katamari").gameObject;
        constellation = transform.Find("Object Constellation").gameObject;
        rb = GetComponent<Rigidbody>();
        vel_threshold = GetComponent<Movement>().maxvelocity / 2;
        RadiusUIText.GetComponent<Text>().text = (System.Math.Round(katamari.transform.localScale.x,2) * 10)+" CM";
        remove_time = 1;
        remove_timer = 0;
        recently_removed = false;
    }

    void Update()
    {
        // updating grow scale, in order to finish the game
        if(katamari.transform.localScale.x > 400)
        {
            growrate = 0.05f;
        }
        
        // calculate mass every second to help performance
        calc_timer += Time.deltaTime;
        if (rb == null) calc_timer = 0;//for tutorial
        if(calc_timer > 1.0f)
        {
            rb.mass = 1.0f + katamari.transform.localScale.x / 100.0f;
            calc_timer = 0.0f;
        }
    }


    private void OnTriggerEnter(Collider collision)
    {
        
        // if player has been kicked, count timer, don't let them get repeatedly hit by AI
        if(recently_removed)
        {
            remove_timer += Time.deltaTime;
        }

        if(remove_timer > remove_time)
        {
            recently_removed = false;
        }

        // find tag of object, if pickup or tile (tiles act differently) start pickup routine
        string tag = collision.GetComponent<Collider>().gameObject.tag;
        if ((tag == "pickup" || tag == "tile") && !collision.isTrigger)
        {

            // get collided game object
            // distance to collision
            // colliders for both objects in collision
            GameObject other = collision.GetComponent<Collider>().gameObject;

            Vector3 loc = (transform.position - other.transform.position) * -1;

            SphereCollider s = katamari.gameObject.GetComponent<SphereCollider>();
            Collider m = other.gameObject.GetComponent<Collider>();     
            
            // changed in by judge 11/14 to fix mesh collider issues

            // compare sizes, attach if smaller
            float sizeofobject = m.bounds.size.magnitude;
            float sizeofplayer = s.bounds.size.magnitude;
            //Debug.Log(sizeofobject + " " + sizeofplayer);
            if (sizeofplayer * attachablemultiplier > sizeofobject)
            {
                // avoid unity errors :p 
                MeshCollider mesh = other.GetComponentInChildren<MeshCollider>();
                if(mesh != null)
                {
                    mesh.convex = true;
                }

                // create copy of
                GameObject copy = null;
                if(tag != "tile")
                {
                    copy = Instantiate(other);
                    Destroy(copy.GetComponent<Rigidbody>());
                }

                //Finding the tile object the item is part of
                GameObject p = other;
                while (p.transform.parent != null)
                {
                    p = p.transform.parent.gameObject;
                }
                
                /*if(tag != "tile" && (m.bounds.size.x> katamari.transform.lossyScale.x || m.bounds.size.y> katamari.transform.lossyScale.x|| m.bounds.size.z >  katamari.transform.lossyScale.x ))
                {
                    other.layer = 11;
                }
                else
                {
                */
                other.layer = 8;
                m.enabled = false;
                //}

                if (other.gameObject.GetComponent<AI>() != null)
                {
                    Destroy(other.gameObject.transform.Find("AISwitch").gameObject);
                }
                // hi this is judge I added this in to make the AI stop moving once you get them
                other.tag = "sticky";
                
                //Debug.Log(new Vector3(sizeofobject,sizeofobject,sizeofobject)*growrate);
                //Vector3 object_size = new Vector3(sizeofobject, sizeofobject, sizeofobject);

                float growth = 2.0f * (Mathf.Pow(sizeofobject * (3.0f / (4.0f * Mathf.PI)), (1.0f / 3.0f))) * growrate;

                katamari.transform.localScale += new Vector3(growth, growth, growth);
                
                float uisize = katamari.transform.localScale.x*10;
                string label;
                if (uisize > 100)
                {
                    label = "M";
                    uisize /= 100;
                }
                else
                {
                    label = "CM";
                }
                uisize = Mathf.Round(uisize*10)/10f;
                RadiusUIText.GetComponent<Text>().text = uisize + " "+label;
                

                foreach (Transform child in UIPickup.transform)
                {
                    GameObject.Destroy(child.gameObject);
                }

                
                if(copy != null && tag != "tile")
                {
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
                    foreach(Transform t in copy.GetComponentsInChildren<Transform>())
                    {
                        t.gameObject.layer = 13;
                    }
                    
                    foreach (Transform child in other.transform)
                    {
                        GameObject.Destroy(child.gameObject);
                    }
                }
                else
                {
                    // for children of tile, delete non-ground tiles, make ground tiles pickup tag
                    foreach(Transform child in other.transform)
                    {
                        if(child.gameObject.layer != 12)
                        {
                            Destroy(child.gameObject);
                        }
                        else
                        {
                            child.gameObject.layer = 8;
                        }
                    }
                }

                
                PickupUIText.GetComponent<Text>().text = other.name;
                // changed by judge 12/1 ... added this condition so small objects will stop being rendered at large sizes, and moved it down here in order to keep the object camera working
                if(sizeofplayer * attachablemultiplier < 5 * sizeofobject)
                {
                    other.transform.position = transform.position + loc;
                    other.transform.parent = constellation.transform;
                }
                else
                {
                    Destroy(other.gameObject);
                }
                Rigidbody rd = other.GetComponent<Rigidbody>();
                Destroy(rd);
            }           
        }
    }

    public void RemoveObjects()
    {
        if(!recently_removed)
        {
            // variables to store total radius reduced and number of items to remove
            Vector3 total_removed = Vector3.zero;
            int n_objects_to_remove = constellation.transform.childCount;

            if(n_objects_to_remove > 10)
            {
                n_objects_to_remove = 10;
            } 
            // for each child of the picked up objects, set parent to null, increment total removed size, count down to 0
            for(int i = constellation.transform.childCount - n_objects_to_remove; i < constellation.transform.childCount; i++)
            { 
                Transform child = constellation.transform.GetChild(i);
                if(i < 0)
                {
                    break;
                }
                
                child.transform.localScale = child.parent.transform.lossyScale;
                child.parent = fallen_objects.transform;
                child.gameObject.AddComponent<Rigidbody>();
                child.gameObject.GetComponent<Rigidbody>().freezeRotation = true;
                child.gameObject.GetComponent<Collider>().enabled = true;
                child.gameObject.layer = 14;
                
                Vector3 launchDirection = (child.position - katamari.transform.position);
                launchDirection.y = 0;
                launchDirection = Vector3.RotateTowards(launchDirection, Vector3.up, Mathf.PI / 4, 10000);
                launchDirection.Normalize();

                GameObject ps = Instantiate(particles[UnityEngine.Random.Range(0, particles.Count)]);
                
                ps.transform.forward = launchDirection;
                ps.transform.parent = child.transform;
                ps.transform.localPosition = new Vector3(0, 0, 0);
                ps.transform.localScale = new Vector3(2, 2, 2);

                Rigidbody child_rb = child.gameObject.GetComponent<Rigidbody>();

                child_rb.AddForce(launchDirection * 200 * katamari.transform.localScale.x);
                
                SphereCollider s = katamari.gameObject.GetComponent<SphereCollider>();
                Collider c = child.gameObject.GetComponentInChildren<Collider>();
                
                float sizeofobject = c.bounds.size.magnitude;
                total_removed += new Vector3(sizeofobject,sizeofobject,sizeofobject)*growrate/s.transform.localScale.x;
                
                AI ai_script = child.GetComponent<AI>();
                Destroy(ai_script);
                child.gameObject.AddComponent<FallenObject>();
                i--;
            }

            // reset size
            katamari.transform.localScale -= total_removed;
            RadiusUIText.GetComponent<Text>().text = (System.Math.Round(katamari.transform.localScale.x,2) * 10)+" CM";
            
        }
    }

    public void ResetUICam()
    {
        PickupUIText.GetComponent<Text>().text = "";
        
        foreach (Transform child in UIPickup.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }  
}