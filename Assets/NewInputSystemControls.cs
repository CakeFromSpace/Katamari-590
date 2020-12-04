using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class NewInputSystemControls : MonoBehaviour
{
    PlayerControls controls;
    Vector2 lmove;
    Vector2 rmove;

    public GameObject katamari;
    public float speed;
    public float spinspeed;
    public float turnspeed;
    public float turnbounds;//how forward does the stick need to be to start turning
    private Rigidbody rb;
    public Vector3 forward;
    float theta;

    bool spinning;
    float spintar;
    float lerp;
   // private void Awake()
   // {

       // controls = new PlayerControls();

       // controls.Controller.LeftMoveTank.performed += c => lmove = c.ReadValue<Vector2>();
       // controls.Controller.LeftMoveTank.canceled += c => lmove = Vector2.zero;

        //controls.Controller.RightMoveTank.performed += c => rmove = c.ReadValue<Vector2>();
        //controls.Controller.RightMoveTank.canceled += c => rmove = Vector2.zero;

        //controls.Controller.Spin.performed += c =>
         //{
         //    spinning = true;
         //    spintar = theta + Mathf.PI;
         //    lerp = 0f;
         //};


    //}

    public void LeftMove(InputAction.CallbackContext c) => lmove = c.ReadValue<Vector2>();
    public void RightMove(InputAction.CallbackContext c) => rmove = c.ReadValue<Vector2>();
    public void Spin(InputAction.CallbackContext c)
    {
        if (!c.performed) return;
        Debug.Log("spin");
        spinning = true;
        spintar = theta + Mathf.PI;
        lerp = 0f;
    }
    public void PausePressed(InputAction.CallbackContext c)
    {
        if (!c.performed) return;
        Debug.Log("imagine it paused");
    }
    private void Start()
    {
        rb = GetComponentInChildren<Rigidbody>();
        theta = 0;
        forward = new Vector3(Mathf.Sin(theta), 0, Mathf.Cos(theta));
    }
    void FixedUpdate()
    {
        //Debug.Log(lmove + " "+rmove);
        forward = new Vector3(Mathf.Sin(theta), 0, Mathf.Cos(theta));
        forward.Normalize();

        if (spinning)
        {
            lerp += Time.deltaTime;
            theta = Mathf.Lerp(theta, spintar, lerp);

            if(theta == spintar)
            {
                theta %= Mathf.PI * 2;
                spinning = false;
            }
            return;
        }

        if (lmove.y != 0)
        {
            rb.AddForce(forward * lmove.y * speed * katamari.transform.localScale.x);
            if(lmove.y> turnbounds || lmove.y<-turnbounds) theta += turnspeed / 100f*lmove.y;
        }
        if (rmove.y != 0)
        {
            rb.AddForce(forward * rmove.y * speed * katamari.transform.localScale.x);
            if (rmove.y > turnbounds || rmove.y < -turnbounds) theta -=turnspeed/100f*rmove.y;
        }
        if (lmove.x != 0)
        {
            if (lmove.y < turnbounds && lmove.y > -turnbounds) rb.AddForce(Quaternion.Euler(0, 90, 0) * forward * lmove.x * speed * katamari.transform.localScale.x);
        }
        if (rmove.x != 0)
        {
            if (rmove.y < turnbounds && rmove.y > -turnbounds) rb.AddForce(Quaternion.Euler(0, 90, 0) * forward * rmove.x * speed * katamari.transform.localScale.x);
        }
    }


}
