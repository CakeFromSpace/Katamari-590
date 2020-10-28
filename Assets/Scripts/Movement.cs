using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;
    public float turnspeed;
    public Vector3 forward;
    public float sqrMaxVelocity;
    public SphereCollider s;
    float theta;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        theta = 0;
        forward = new Vector3(Mathf.Sin(theta), 0, Mathf.Cos(theta));
        s = GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        if (Input.GetKey(KeyCode.UpArrow) && rb.velocity.sqrMagnitude < sqrMaxVelocity * transform.localScale.x * s.radius)
        {
            rb.AddForce(forward*speed*transform.localScale.x * s.radius);
        }
        if (Input.GetKey(KeyCode.DownArrow) && rb.velocity.sqrMagnitude < sqrMaxVelocity * transform.localScale.x * s.radius / 2)
        {
            rb.AddForce(-forward * speed*transform.localScale.x * s.radius);
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
