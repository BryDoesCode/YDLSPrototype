using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public AudioSource[] musicSources;
    public double loopPoint;
    private double time;
    private int nextSource;

    void Start()
    {
        time = AudioSettings.dspTime;
        musicSources[0].Play();
        nextSource = 1;
    }

    void Update()
    {
        if (!musicSources[nextSource].isPlaying)
        {
            time += loopPoint;
            musicSources[nextSource].PlayScheduled(time);
            nextSource = 1 - nextSource;
        }
    }
}
