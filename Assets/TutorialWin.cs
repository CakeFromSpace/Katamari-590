using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialWin : MonoBehaviour
{
    public GameObject player;
    public GameObject particles;
    public GameObject finishpanel;
    // Update is called once per frame
    void Update()
    {
        if(gameObject.tag == "sticky")
        {
            particles.SetActive(true);
            finishpanel.SetActive(true);
            Destroy(player.GetComponent<NewInputSystemControls>());
            Destroy(player.GetComponent<Rigidbody>());
            Destroy(this);
        }
    }
}
