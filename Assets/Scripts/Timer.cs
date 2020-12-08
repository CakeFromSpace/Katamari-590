using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DentedPixel;

public class Timer : MonoBehaviour
{
    public GameObject timer;
    public int t;
    // Start is called before the first frame update
    void Start()
    {
        StartTimer();
        
    }
    public void StartTimer()
    {
        LeanTween.scaleX(timer, 1, t);
    }
}
