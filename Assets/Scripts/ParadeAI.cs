using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParadeAI : AI
{
    public float velocity;
    public float change_direction_time;
    public float complete_turn_time;
    public float t;
    public float looking_distance;
    public float push_strength;
    public LayerMask mask;
    private float direction_timer;
    private float moveAngle;
    private float size;
    private Vector3 y_offset;
    private GameObject player;
    private Quaternion rotation;
    private int angle;

    // Start is called before the first frame update
    void Start()
    {   
        
        angle = 0;
        rotation = transform.rotation;
        Bounds bounds = GetComponent<Collider>().bounds;
        y_offset = new Vector3(0, bounds.center.y / 2, 0);
        direction_timer = 0;
        size = bounds.size.x * bounds.size.y * bounds.size.z;
    }

    // Update is called once per frame
    void Update()
    {
        direction_timer += Time.deltaTime;
        
        if(gameObject.tag != "sticky")
        {
            if(Quaternion.Angle(transform.rotation,rotation) == 0)
            {
                transform.position += (velocity * transform.forward) * Time.deltaTime;  
            }
            if(direction_timer > change_direction_time)
            {
                rotation = Quaternion.AngleAxis(angle % 360, transform.up);
                direction_timer = 0;
                angle += 180;
            } 
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 2);
        }
    }

}
