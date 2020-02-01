using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class OptionsReturnSaveMuzika : MonoBehaviour
{
    public float muzika = 0.5f;

    public void SpremanjePostavki(float value)
    {
        muzika = value;
        PlayerPrefs.SetFloat("muzika", muzika);
    }
}
