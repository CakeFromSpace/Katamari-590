using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        menu.SetActive(true);
        gameObject.SetActive(false);
    }
}
