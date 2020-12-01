using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParadeAI : MonoBehaviour
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
    private bool flee;
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
        flee = false;
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

    void Wander()
    {

        // if it's time to change direction, pick a random angle and reset direction_timer
        if(direction_timer > change_direction_time)
        {
            moveAngle = Random.Range(0, 360);
            direction_timer = 0;
        }

        // apply lerp rotation, move forwards, move forwards
        Vector3 eulerAngles = transform.eulerAngles;
        eulerAngles.y = Mathf.LerpAngle(eulerAngles.y, moveAngle, direction_timer / complete_turn_time);
        transform.eulerAngles = eulerAngles;
        transform.position += (velocity * transform.forward) * Time.deltaTime;
        
    }

    void Flee()
    {
        // get direction of player
        Vector3 direction_of_player = player.transform.position - transform.position;
        direction_of_player = Vector3.Normalize(new Vector3(direction_of_player.x, 0, direction_of_player.z));

        // lerp rotation away from player and move at double speed
        transform.forward = Vector3.Lerp(transform.forward, -1 * direction_of_player, 10 * t);
        transform.position += (-1 * 2 * velocity * direction_of_player) * Time.deltaTime;
    }

    void TurnAround()
    {
        // turn 180 degrees w quaternion slerp
    }

    void AvoidObstacle(RaycastHit hit)
    {
        // adjust forward in the direction of the norm of the hit
        Vector3 norm = hit.normal;
        norm.y = 0;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(transform.forward + norm * 30.0f), 2 * Time.deltaTime);
        
    }


    private void OnTriggerEnter(Collider other)
    {
        // if entering the katamaris trigger
        if (other.gameObject.name == "katamari")
        {
            // start running, get reference to katamari
            player = other.gameObject;

            // depending on size, run away or towards it
            SphereCollider s = player.GetComponent<SphereCollider>();
            if(s.bounds.size.magnitude > size)
            {
                flee = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // reset state on trigger exit
        if (other.gameObject.name == "katamari")
        {
            flee = false;
        }
    }
}
