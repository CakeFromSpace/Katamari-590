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
    public KeyCode up;
    public KeyCode down;
    public KeyCode left;
    public KeyCode right;
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
        if (Input.GetKey(up)&&rb.velocity.magnitude<maxvelocity)
        {
            rb.AddForce(forward*speed);
            //rb.AddTorque(Quaternion.AngleAxis(90,Vector3.up)*forward * speed);
        }
        if (Input.GetKey(down) && rb.velocity.magnitude < maxvelocity)
        {
            rb.AddForce(-forward * speed);  
        }
        if (Input.GetKey(left))
        {
            theta -= turnspeed/100f;
            
            forward = new Vector3(Mathf.Sin(theta), 0, Mathf.Cos(theta));
            forward.Normalize();
        }
        if (Input.GetKey(right))
        {
            theta += turnspeed/100f;

            forward = new Vector3(Mathf.Sin(theta), 0, Mathf.Cos(theta));
            forward.Normalize();
        }
    }
}
