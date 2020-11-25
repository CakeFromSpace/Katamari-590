using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : MonoBehaviour
{
    public GameObject katamari;
    public KeyCode leftup;
    public KeyCode leftdown;
    public KeyCode leftleft;
    public KeyCode leftright;

    public KeyCode rightup;
    public KeyCode rightdown;
    public KeyCode rightleft;
    public KeyCode rightright;

    public KeyCode spin;
    public float spinspeed;
    private Rigidbody rb;
    public float speed;
    public float turnspeed;
    public Vector3 forward;
    float theta;
    bool spinning;
    float spintar;
    float lerp;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        theta = 0;
        forward = new Vector3(Mathf.Sin(theta), 0, Mathf.Cos(theta));
    }

    // Update is called once per frame
    void Update()
    {
        forward = new Vector3(Mathf.Sin(theta), 0, Mathf.Cos(theta));
        forward.Normalize();
        if (spinning)
        {
            lerp += Time.deltaTime;
            theta = Mathf.Lerp(theta, spintar, lerp);

            if (theta == spintar)
            {
                theta %= Mathf.PI * 2;
                spinning = false;
            }
            return;
        }
        if (Input.GetKey(leftup))
        {
            rb.AddForce(forward * speed/2f * katamari.transform.localScale.x);
            theta += turnspeed/100f;

        }
        if (Input.GetKey(rightup))
        {
            rb.AddForce(forward * speed/2f * katamari.transform.localScale.x);
            theta -= turnspeed/100f;
        }
        if (Input.GetKey(leftdown))
        {
            rb.AddForce(-forward * speed/2f * katamari.transform.localScale.x);
            theta -= turnspeed / 100f;

        }
        if (Input.GetKey(rightdown))
        {
            rb.AddForce(-forward * speed/2f * katamari.transform.localScale.x);
            theta += turnspeed / 100f;
        }
        if (Input.GetKey(leftleft))
        {
            rb.AddForce(Quaternion.Euler(0,-90,0)*forward * speed/2f * katamari.transform.localScale.x);

        }
        if (Input.GetKey(rightleft))
        {
            rb.AddForce(Quaternion.Euler(0, -90, 0) * forward * speed/2f * katamari.transform.localScale.x);
        }
        if (Input.GetKey(leftright))
        {
            rb.AddForce(Quaternion.Euler(0, 90, 0) * forward * speed/2f * katamari.transform.localScale.x);

        }
        if (Input.GetKey(rightright))
        {
            rb.AddForce(Quaternion.Euler(0, 90, 0) * forward * speed/2f * katamari.transform.localScale.x);
        }
        if (Input.GetKey(spin))
        {
            spinning = true;
            spintar = theta + Mathf.PI;
            lerp = 0f;

        }

        
    }

    
}
