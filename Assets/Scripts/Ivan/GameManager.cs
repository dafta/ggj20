﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool isPaused = false;
    public GameObject PauseScreen;
    public Text Timer;
    private float timer;
    private int minute;
    private int sekunde;

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void Update()
    {
        timer += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused == false)
            {
                isPaused = true;
                Time.timeScale = 0;
                SceneManager.LoadScene(0);
            }
            else
            {
                isPaused = false;
                Time.timeScale = 1;
                SceneManager.LoadScene(1);
            }
        }
        minute = (int)timer / 60;
        sekunde = (int)timer % 60;
        if(minute < 10)
        {
            Timer.text = "0" + minute.ToString() + ":";
            if (minute < 10)
                Timer.text += "0" + sekunde;
            else
                Timer.text += sekunde;
        }
        else
        {
            Timer.text = minute.ToString() + ":";
            if (minute < 10)
                Timer.text += "0" + sekunde;
            else
                Timer.text += sekunde;
        }

    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
