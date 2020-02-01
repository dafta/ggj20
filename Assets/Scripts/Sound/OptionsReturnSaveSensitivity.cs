using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class OptionsReturnSaveSensitivity : MonoBehaviour
{
    public float sensitivity = 7f;

    public void SpremanjePostavki(float value)
    {
        sensitivity = value;
        PlayerPrefs.SetFloat("sensitivity", sensitivity);
    }
}
