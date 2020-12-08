using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Author Joe
public class ItemRing : MonoBehaviour
{
    public GameObject item;
    public float radius;
    public int numberofitems;
    public float speed;
    public bool clockwise;
    public float rotation;
    // Start is called before the first frame update
    void Start()
    {
        speed = 0;
        float d = 2 * Mathf.PI / numberofitems;
        for(int i = 0; i < numberofitems; i++)
        {
            GameObject a = Instantiate(item, transform);
            a.transform.localPosition = new Vector3(Mathf.Sin(d*i),0,Mathf.Cos(d*i))*radius;
            a.transform.rotation = Quaternion.Euler(0,(360/numberofitems*i)+rotation,0);
            a.name = item.name;
            
        }
    }

    // Removed because framerate issues :(

    void notUpdate()
    {
        transform.Rotate(0, clockwise?Time.deltaTime*speed: Time.deltaTime * -speed, 0);
        if (transform.childCount == 0) Destroy(this.gameObject);
    }
}
