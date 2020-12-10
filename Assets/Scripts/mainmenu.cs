using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//Debankita
public class mainmenu : MonoBehaviour
{
    public GameObject player;
    public GameObject menu;
    public GameObject volume;
    public GameObject timeactive;
    public GameObject greenbaractive;
    public GameObject numtime;
    //player is the activate
    public bool activate;
  
    public void Play()
    {
        activate = true;
        if (activate == true)
        {
            player.SetActive(true);
            menu.SetActive(false);
            timeactive.SetActive(true);
            numtime.SetActive(true);
        }
        
    }
   
    public void HowtoPlay()
    {
        activate = false;
        SceneManager.LoadScene("Tutorial");
    }
    public void Settings()
    {
        activate = false;
        volume.SetActive(true);
        menu.SetActive(false);
        

    }
    public void Back()
    {
        activate = false;
        menu.SetActive(true);
        volume.SetActive(false);
    }
    
    
}
