using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientVolume : MonoBehaviour
{
    public AudioSource pozadina;
    void Start()
    {
        GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("ambient");
    }
}
