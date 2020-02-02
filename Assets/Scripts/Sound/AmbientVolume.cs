using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientVolume : MonoBehaviour
{
    void Update()
    {
        AudioListener.volume = PlayerPrefs.GetFloat("ambient");
        Debug.Log(PlayerPrefs.GetFloat("ambient")); 
    }
}
