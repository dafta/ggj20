using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartPuzzle : MonoBehaviour
{
    [Header("Text References")]
    public Text puzzleStartText;

    [Header("Player")]
    public GameObject player;

    [Header("Puzzles")]
    public GameObject puzzleTutorial;
    public GameObject puzzle1;
    public GameObject puzzle2;
    public GameObject puzzle3;

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "PuzzleTutorialStart")
        {
            puzzleStartText.text = "Press Q to start puzzle";

            if (Input.GetKeyDown(KeyCode.Q))
            {
                puzzleStartText.text = "";

                player.SetActive(false);
                puzzleTutorial.SetActive(true);
            }
        }

        if (other.tag == "Puzzle1Start")
        {
            puzzleStartText.text = "Press Q to start puzzle";

            if (Input.GetKeyDown(KeyCode.Q))
            {
                puzzleStartText.text = "";

                player.SetActive(false);
                puzzle1.SetActive(true);
            }
        }

        if (other.tag == "Puzzle2Start")
        {
            puzzleStartText.text = "Press Q to start puzzle";

            if (Input.GetKeyDown(KeyCode.Q))
            {
                puzzleStartText.text = "";

                player.SetActive(false);
                puzzle2.SetActive(true);
            }
        }

        if (other.tag == "Puzzle3Start")
        {
            puzzleStartText.text = "Press Q to start puzzle";

            if (Input.GetKeyDown(KeyCode.Q))
            {
                puzzleStartText.text = "";

                player.SetActive(false);
                puzzle3.SetActive(true);
            }
        }
    }
}
