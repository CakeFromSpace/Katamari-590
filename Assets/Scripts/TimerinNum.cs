using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimerinNum : MonoBehaviour
{
    float currtime = 0f;
    float starttime = 15f;
    private Text num;
    public GameObject time;
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
            currtime = 0;
    }
}
