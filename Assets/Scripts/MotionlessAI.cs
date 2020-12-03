using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionlessAI : AI
{
    private AudioSource sound;

    // Start is called before the first frame update
    void Start()
    {   
        sound = GetComponent<AudioSource>();
        dead = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(gameObject.tag != "sticky")
        {
            
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
}
