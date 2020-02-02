using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    void Start()
    {
        Invoke("GameOver2", 9f);
    }

    public void GameOver2()
    {
        SceneManager.LoadScene(0);
    }
}
