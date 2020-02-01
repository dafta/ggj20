using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class OptionsReturnSave : MonoBehaviour
{
    public float muzika;

    public void SpremanjePostavki(float value)
    {
        muzika = Mathf.RoundToInt(value);
    }
}
