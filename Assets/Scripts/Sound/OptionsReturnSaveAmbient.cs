using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class OptionsReturnSaveAmbient : MonoBehaviour
{
    public float ambient = 0.5f;

    public void SpremanjePostavki(float value)
    {
        ambient = value;
        PlayerPrefs.SetFloat("ambient", ambient);
    }
}
