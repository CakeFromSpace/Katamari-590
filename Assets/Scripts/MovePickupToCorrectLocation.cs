using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Written by Joe
//Moves Pickup UI to correct location
public class MovePickupToCorrectLocation : MonoBehaviour
{
    
    public GameObject pickup;

    // Start is called before the first frame update
    void Start()
    {
        float horiz = gameObject.GetComponent<Camera>().orthographicSize;
        Vector3 camloc = transform.position;
        camloc.x -= horiz*1.50f;
        camloc.y -= horiz*.65f;
        camloc.z += 1;
        pickup.transform.position = camloc;
    }
}
