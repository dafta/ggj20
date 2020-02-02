using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{

    public void OnTriggerEnter(Collider other)
    {
        PlayerPrefs.SetFloat("X", 8.35f);
        PlayerPrefs.SetFloat("Y", 3.06f);
        PlayerPrefs.SetFloat("Z", 88.09f);

        PlayerPrefs.SetInt("wing", 0);
        PlayerPrefs.SetInt("gas", 0);
        PlayerPrefs.SetInt("screwdriver", 0);
        PlayerPrefs.SetInt("elisa", 0);

        PlayerPrefs.SetInt("tutorialStatus", 0);

        PlayerPrefs.SetInt("tower1Status", 0);
        PlayerPrefs.SetInt("tower2Status", 0);
        PlayerPrefs.SetInt("tower3Status", 0);

        PlayerPrefs.SetInt("counter", 0);

        Cursor.lockState = CursorLockMode.None;

        SceneManager.LoadScene(2);
    }
}
