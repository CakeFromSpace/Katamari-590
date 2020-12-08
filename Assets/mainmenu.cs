using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenu : MonoBehaviour
{
    public GameObject player;
    public GameObject menu;
//player is the activate
    public bool activate;
  
    public void Play()
    {
        if (activate == true)
        {
            player.SetActive(true);
            menu.SetActive(false);
            
        }
        
    }
  
    public void HowtoPlay()
    {

        SceneManager.LoadScene("Tutorial");
    }
    
    
}
