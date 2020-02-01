using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleController : MonoBehaviour
{
    [Header("Player")]
    public GameObject player;

    [Header("Puzzle")]
    public GameObject puzzle;
    public GameObject puzzleStarter;

    private bool exitable = false;

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Q))
        {
            exitable = true;
        }

        if (Input.GetKeyDown(KeyCode.Q) && exitable)
        {
            exitable = false;

            puzzle.SetActive(false);
            player.SetActive(true);
        }
    }

    void OnTriggerEnter(Collider other) {
        puzzleStarter.SetActive(false);
        puzzle.SetActive(false);
        player.SetActive(true);
    }
}
