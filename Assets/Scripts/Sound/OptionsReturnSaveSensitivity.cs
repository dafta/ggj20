using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class OptionsReturnSaveSensitivity : MonoBehaviour
{
    public float sensitivity = 0.5f;

    public void SpremanjePostavki(float value)
    {
        sensitivity = value;
        PlayerPrefs.SetFloat("sensitivity", sensitivity);
    }
}
