using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientMusic : MonoBehaviour
{
    public AudioSource sound;
    private bool isPlaying = false;
    private bool finishedPlaying = false;
    void Start()
    {
        sound = GetComponent<AudioSource>();
        isPlaying = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(isPlaying == false && finishedPlaying == false)
        {
            sound.Play();
            isPlaying = true;
        }
        else if(isPlaying == true &&  finishedPlaying == false)
        {
            sound.Stop();
            finishedPlaying = false;
        }
    }
}
