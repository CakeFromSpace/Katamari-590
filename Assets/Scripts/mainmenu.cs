using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
  
    public void HowtoPlay()
    {
        SceneManager.LoadScene("HowtoPlay");

    }
    public void Back()
    {
        SceneManager.LoadScene("Main Menu");
    }
    
}
