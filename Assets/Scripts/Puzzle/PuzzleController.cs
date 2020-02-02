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

    public GameObject tower;

    public int puzzleNo;

    private bool exitable = false;

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.R))
        {
            exitable = true;
        }

        if (Input.GetKeyDown(KeyCode.R) && exitable)
        {
            exitable = false;

            puzzle.SetActive(false);
            player.SetActive(true);
        }
    }

    void OnTriggerEnter(Collider other) {
        PickupItems pi = player.GetComponent<PickupItems>();

        if (puzzleNo == 1)
        {
            pi.tower1Status = 1;
            PlayerPrefs.SetInt("tower1Status", pi.tower1Status);
            tower.GetComponent<FixTower>().Destroy();
        } else if (puzzleNo == 2)
        {
            pi.tower2Status = 2;
            PlayerPrefs.SetInt("tower2Status", pi.tower2Status);
            tower.GetComponent<FixTower>().Destroy();
        } else if (puzzleNo == 3)
        {
            pi.tower3Status = 3;
            PlayerPrefs.SetInt("tower3Status", pi.tower3Status);
            tower.GetComponent<FixTower>().Destroy();
        }

        puzzleStarter.SetActive(false);
        puzzle.SetActive(false);
        player.SetActive(true);
    }
}
