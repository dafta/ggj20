using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientVolume : MonoBehaviour
{
    void Update()
    {
        AudioListener.volume = PlayerPrefs.GetFloat("ambient", 0.5f);
        Debug.Log(PlayerPrefs.GetFloat("ambient"));
    }
}
