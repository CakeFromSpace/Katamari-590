using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Author Joe
public class PauseUI : MonoBehaviour
{
    
    public void Unpause()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }
    public void ToMainMenu()
    {
        Debug.Log("Pretend this button brought you to the main menu");
    }
}
