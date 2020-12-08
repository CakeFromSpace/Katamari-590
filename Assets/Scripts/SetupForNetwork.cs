using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class SetupForNetwork : NetworkBehaviour
{
    void Start()
    {
        GameObject cam = gameObject.transform.GetChild(2).gameObject;
        if (isLocalPlayer)
        {
            cam.GetComponent<Chase>().target = gameObject;
            cam.GetComponent<Chase>().katamari = gameObject.transform.GetChild(0).gameObject;
        }
        else
        {
            Destroy(cam);
            Destroy(gameObject.GetComponent<Movement>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
