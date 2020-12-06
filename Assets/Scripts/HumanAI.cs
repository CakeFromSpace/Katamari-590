using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanAI : AI
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
    private bool chase;
    //private bool dead;
    private Vector3 y_offset;
    private GameObject player;
    private Animator animation_controller;
    private AudioSource sound;

    





    // Start is called before the first frame update
    void Start()
    {   
        sound = GetComponent<AudioSource>();
        Bounds bounds = GetComponent<Collider>().bounds;
        y_offset = new Vector3(0, bounds.center.y / 2, 0);
        animation_controller = GetComponent<Animator>();
        flee = false;
        chase = false;
        dead = false;
        direction_timer = 0;
        moveAngle = Random.Range(0, 360);
        size = bounds.size.magnitude;
    }

    // Update is called once per frame
    void Update()
    {
        
        direction_timer += Time.deltaTime;
        
        if(gameObject.tag != "sticky")
        {
            
            // rays
            Ray f = new Ray (transform.position + transform.forward * 1.5f + y_offset, transform.forward);
            Ray l = new Ray (transform.position + transform.forward * 1.5f + transform.right * 3 + y_offset, transform.forward);
            Ray r = new Ray (transform.position + transform.forward * 1.5f - transform.right * 3 + y_offset, transform.forward);


            RaycastHit hit;
            
            // if raycast hits
            if((Physics.Raycast(l, out hit, looking_distance, mask, QueryTriggerInteraction.Ignore) && Physics.Raycast(r, out hit, looking_distance, mask, QueryTriggerInteraction.Ignore)) || Physics.Raycast(f, out hit, looking_distance, mask, QueryTriggerInteraction.Ignore))
            {
                TurnAround();
            }
            if(Physics.Raycast(l, out hit, looking_distance, mask, QueryTriggerInteraction.Ignore) || Physics.Raycast(r, out hit, looking_distance, mask, QueryTriggerInteraction.Ignore) || Physics.Raycast(f, out hit, looking_distance, mask, QueryTriggerInteraction.Ignore))
            {
                Debug.DrawLine(transform.position + transform.forward * 1.5f + y_offset, transform.position + transform.forward * 1.5f + y_offset + transform.forward * looking_distance, Color.white, 1f);
                Debug.DrawLine(transform.position + transform.forward * 1.5f + transform.right * 3 + y_offset, transform.position + transform.forward * 1.5f + transform.right * 3 + y_offset + transform.forward * looking_distance, Color.red, 1f);
                Debug.DrawLine(transform.position + transform.forward * 1.5f - transform.right * 3 + y_offset, transform.position + transform.forward * 1.5f - transform.right * 3 + y_offset+ transform.forward * looking_distance, Color.blue, 1f);
                Debug.DrawLine(transform.position + y_offset, hit.transform.position, Color.white, 1f);
                direction_timer = change_direction_time;
                AvoidObstacle(hit);
            }
            else if(flee)
            {
                Flee();
            }
            else if(chase)
            {
                Chase();
            }
            else
            {
                Wander();
            }
        }
        else if(!dead)
        {
            dead = true;
            if(sound != null)
            {
                sound.Play();
            }
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

    void Chase()
    {
        //Debug.Log("Chase");
        // get direction of player
        Vector3 direction_of_player = player.transform.position - transform.position;
        if(direction_of_player.magnitude < looking_distance * 2)
        {
            Vector3 push = Vector3.Normalize(player.transform.position - transform.position) * push_strength * 10;
            push.y = 0;
            player.transform.parent.gameObject.GetComponent<Rigidbody>().AddForce(push);
            if(sound != null)
            {
                sound.Play();
            }
            return;
        }
        direction_of_player = Vector3.Normalize(new Vector3(direction_of_player.x, 0, direction_of_player.z));

        // lerp rotation away from player and move at double speed
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction_of_player), 1);
        transform.position += (2 * velocity * direction_of_player) * Time.deltaTime;
    
    }

    void Flee()
    {
        //Debug.Log("Flee");
        // get direction of player
        Vector3 direction_of_player = transform.position - player.transform.position;
        direction_of_player = Vector3.Normalize(new Vector3(direction_of_player.x, 0, direction_of_player.z));

        // lerp rotation away from player and move at double speed
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction_of_player), 1);
        transform.position += (2 * velocity * direction_of_player) * Time.deltaTime;
    }

    void TurnAround()
    {
        float[] angles = {90, 180, 270};
        float turn_angle = angles[UnityEngine.Random.Range(0, angles.Length)];
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.AngleAxis(transform.eulerAngles.y + turn_angle, new Vector3(0, 1, 0)), 1);
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
            animation_controller.SetBool("run", true);
            player = other.gameObject;

            // depending on size, run away or towards it
            SphereCollider s = player.GetComponent<SphereCollider>();
            if(s.bounds.size.magnitude * .7 > size)
            {
                flee = true;
            }
            else
            {
                chase = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // reset state on trigger exit
        if (other.gameObject.name == "katamari")
        {
            animation_controller.SetBool("run", false);
            flee = false;
            chase = false;
        }
    }
}
