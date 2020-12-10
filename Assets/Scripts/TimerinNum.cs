using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimerinNum : MonoBehaviour
{   
    float currtime = 0f;
    float starttime = 300.0f;
    public Text num;
    public GameObject lostmessage;
    public GameObject time;
    public GameObject player;
    

    // Start is called before the first frame update
    void Start()
    {   
        currtime = starttime;
    }

    // Update is called once per frame
    void Update()
    {
        currtime -= 1 * Time.deltaTime;
        num.text = currtime.ToString("0");
        if (currtime <= 0)
        {
            currtime = 0f;
            player.SetActive(false);
            time.SetActive(false);
            lostmessage.SetActive(true);
            
            Start();
            
            
            
        }
    }
}
