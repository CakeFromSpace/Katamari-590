using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissile : MonoBehaviour
{
    public float init_speed;
    public float acceleration;
    public float max_turn;
    public float explode_distance;
    public AudioClip explode;
    public GameObject model;
    public GameObject player;
    private bool dead;
    // Start is called before the first frame update
    void Start()
    {
        dead = false;
        init_speed = 100f;
        acceleration = 1f;
        max_turn = 5;
        explode_distance = 4;
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        // if close but not collided to player, explode (((this is to stop an issue of the missile orbiting around the player)))
        if((player.transform.position - transform.position).magnitude < explode_distance)
        {
            Explode();
            PushPlayer();
        }
        // move forwards, change rotation to face player with max turning angle max_turn
        if(!dead)
        {
            transform.position += transform.forward * (init_speed + acceleration * Time.deltaTime) * Time.deltaTime;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(player.transform.position - transform.position), max_turn);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // if in the avoid proj collision layer, do nothing (avoid hitting the tank)
        if(collision.gameObject.layer != 14)
        {
            Explode();
            if(collision.gameObject.tag == "Player")
            {
                PushPlayer();
            }
        }
    }

    private void Explode()
    {
        // to avoid exploding twice
        if(!dead)
        {
            dead = true;

            // destroy model, keep fire/smoke
            model.SetActive(false);
            Destroy(GetComponent<BoxCollider>());
            ParticleSystem[] ps = GetComponentsInChildren<ParticleSystem>();

            // switch fire/smoke from cone to sphere (looks nice)
            foreach(ParticleSystem p in ps)
            {
                var shape = p.shape;
                shape.shapeType = ParticleSystemShapeType.Sphere;
            
            }

            // play explosion audio clip
            AudioSource a = GetComponentInChildren<AudioSource>();
            a.Stop();
            a.PlayOneShot(explode);

            // destroy gameobject when explosion is over
            Destroy(this.gameObject, explode.length / 2);
        }
    }

    private void PushPlayer()
    {
        // pushes the player backwards
        Vector3 push = Vector3.Normalize(player.transform.position - transform.position) * 1000;
        push.y = 0;
        player.gameObject.GetComponent<Rigidbody>().AddForce(push);
    }
}
