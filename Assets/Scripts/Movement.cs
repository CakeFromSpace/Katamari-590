using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;
    public float maxvelocity;
    public float turnspeed;
    public Vector3 forward;
    float theta;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        theta = 0;
        forward = new Vector3(Mathf.Sin(theta), 0, Mathf.Cos(theta));
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        if (Input.GetKey(KeyCode.UpArrow)&&rb.velocity.magnitude<maxvelocity)
        {
            rb.AddForce(forward*speed);
            //rb.AddTorque(Quaternion.AngleAxis(90,Vector3.up)*forward * speed);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            if(rb.velocity.magnitude > maxvelocity * transform.localScale.x / 2)
            {
                rb.velocity = new Vector3((maxvelocity / 2 * -forward).x, rb.velocity.y, (maxvelocity / 2 * -forward).z);
            }
            else
            {
                rb.AddForce(-forward * speed*transform.localScale.x);
            }    
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            theta -= turnspeed/100f;
            
            forward = new Vector3(Mathf.Sin(theta), 0, Mathf.Cos(theta));
            forward.Normalize();
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            theta += turnspeed/100f;

            forward = new Vector3(Mathf.Sin(theta), 0, Mathf.Cos(theta));
            forward.Normalize();
        }
    }
}
