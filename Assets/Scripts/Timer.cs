using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DentedPixel;
//Debankita
public class Timer : MonoBehaviour
{
    
    public GameObject timer;
    public GameObject lostmessage;
    public GameObject player;
    public int t;
    // Start is called before the first frame update
    void Start()
    {   
        
        StartTimer();
        
    }
    public void StartTimer()
    {
        LeanTween.scaleX(timer, 1, t).setOnComplete(LostMessage);
        //LeanTween.reset();
    }
    
    void LostMessage()
    {
        player.SetActive(false);
        lostmessage.SetActive(true);
        LeanTween.reset();


    }
}
