using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//Author Joe
public class PauseUI : MonoBehaviour
{
    public GameObject menu;
    

    public void Unpause()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }
    public void ToMainMenu()
    {
        SceneManager.LoadScene("making_tiles");
        menu.SetActive(true);
        gameObject.SetActive(false);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
