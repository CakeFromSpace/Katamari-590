using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    internal bool dead;



    //Edit 12/3 Joe
    //Disable AI if distance is far away
    private void Awake()
    {
        GameObject s = new GameObject("AISwitch");
        s.AddComponent<AISwitch>();
        s.transform.parent = transform;
    }


    // Start is called before the first frame update
    void Start()
    {   
        dead = false;
    }

}
