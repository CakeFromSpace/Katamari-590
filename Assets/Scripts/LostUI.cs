using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Debankita
public class LostUI : MonoBehaviour
{
    public GameObject menu;
    public GameObject player;
    public GameObject lostmessage;
    public GameObject timeactive;
    // Start is called before the first frame update
    public void PlayAgain()
    {
        player.SetActive(true);
        lostmessage.SetActive(false);
        timeactive.SetActive(true);
    }
    public void Quit()
    {
        menu.SetActive(true);
        lostmessage.SetActive(false);

    }

}
