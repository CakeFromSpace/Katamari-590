﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimerinNum : MonoBehaviour
{   
    float currtime = 0f;
    //float starttime = 20f;
    public Text num;
    public GameObject lostmessage;
    public GameObject time;
    public GameObject player;
    mainmenu m; 

    // Start is called before the first frame update
    void Start()
    {
        m = GetComponent<mainmenu>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m.activate == true)
        {
            currtime += Time.deltaTime;
            int sec = (int)(currtime % 60);
            int min = (int)(currtime / 60) % 60;
            string format = string.Format("{0:00}:{1:00}", min, sec);
            num.text = format;
            if (currtime >= 10)
            {
                Reload();

            }
        }
    }
    void Reload()
    {
        
       
            currtime = 0f;
            player.SetActive(false);
            time.SetActive(false);
            lostmessage.SetActive(true);
        
    }
}
