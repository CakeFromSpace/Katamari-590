using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Author Joe
public class TutorialLevel : MonoBehaviour
{
    public GameObject player;
    public GameObject startbox;
    public GameObject camera;
    // Update is called once per frame
    public void StartLevel()
    {
        player.GetComponent<NewInputSystemControls>().enabled = true;
        startbox.SetActive(false);
        camera.GetComponent<Chase>().enabled = true;
    }
}
