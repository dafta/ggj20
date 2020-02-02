using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientMusic : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        AudioListener.volume = PlayerPrefs.GetFloat("muzika", 0.5f);
        //Debug.Log(PlayerPrefs.GetFloat("muzika"));
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
