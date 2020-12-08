using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Music : MonoBehaviour
{
    // code by Judge Russell 11 28 2020
    public float volume;
    public GameObject katamari;
    private AudioSource[] tracks;
    private bool[] playing;
    private float old_size;

    // Start is called before the first frame update
    void Start()
    {
        volume = 1.0f;
        old_size = 0.0f;
        tracks = GetComponents<AudioSource>();
        playing = new bool[5];
        playing[0] = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(katamari.transform.localScale.x >= 10 && old_size < 10)
        {
            FadeIn(1);
            playing[1] = true;
        }
        if(katamari.transform.localScale.x >= 50 && old_size < 50)
        {
            FadeIn(2);
            playing[2] = true;
        }
        if(katamari.transform.localScale.x >= 100 && old_size < 100)
        {
            FadeIn(3);
            playing[3] = true;
        }
        if(katamari.transform.localScale.x >= 400 && old_size < 400)
        {
            for(int i = 0; i < 4; i++)
            {
                FadeOut(i);
                playing[i] = false;
            }
            FadeIn(4);
            playing[4] = true;
        }
    
        old_size = katamari.transform.localScale.x;
    }

    public void FadeIn(int track)
    {
        StartCoroutine(Fade(tracks[track], 5.0f, 1.0f));
    }

    public void FadeOut(int track)
    {
        StartCoroutine(Fade(tracks[track], 5.0f, 0.0f));
    }

    IEnumerator Fade(AudioSource track, float duration, float level)
    {
        float currentTime = 0;
        float start = track.volume;

        while(currentTime < duration)
        {
            currentTime += Time.deltaTime;
            track.volume = Mathf.Lerp(start, level, currentTime / duration);
            yield return null;
        }
        yield break;
    }

    public void ChangeVolume(float vol)
    {
        volume = vol;

        for(int i = 0; i < playing.Length; i++)
        {
            if(playing[i] == true)
            {
                StartCoroutine(Fade(tracks[i], 0.01f, vol));
            }
        }
    }


}
