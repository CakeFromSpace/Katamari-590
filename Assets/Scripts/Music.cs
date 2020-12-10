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
    private Coroutine[] fade_tracks;

    // Start is called before the first frame update
    void Start()
    {
        volume = 1.0f;
        old_size = 0.0f;
        tracks = GetComponents<AudioSource>();
        playing = new bool[5];
        playing[0] = true;
        fade_tracks = new Coroutine[5];
    }

    // Update is called once per frame
    void Update()
    {
        if(katamari.transform.localScale.x >= 10 && old_size < 10)
        {
            fade_tracks[1] = StartCoroutine(Fade(tracks[1], 5.0f, volume));
            playing[1] = true;
        }
        if(katamari.transform.localScale.x >= 25 && old_size < 25)
        {
            fade_tracks[2] = StartCoroutine(Fade(tracks[2], 5.0f, volume));
            playing[2] = true;
        }
        if(katamari.transform.localScale.x >= 200 && old_size < 200)
        {
            fade_tracks[3] = StartCoroutine(Fade(tracks[3], 5.0f, volume));
            playing[3] = true;
        }
        if(katamari.transform.localScale.x >= 400 && old_size < 400)
        {
            for(int i = 0; i < 4; i++)
            {
                StartCoroutine(Fade(tracks[i], 5.0f, 0.0f));
                playing[i] = false;
            }
            fade_tracks[4] = StartCoroutine(Fade(tracks[4], 5.0f, volume));
            playing[4] = true;
        }
    
        old_size = katamari.transform.localScale.x;
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
                if(fade_tracks[i] != null) { StopCoroutine(fade_tracks[i]); }
                StartCoroutine(Fade(tracks[i], 0.01f, vol));
            }
        }
    }


}
