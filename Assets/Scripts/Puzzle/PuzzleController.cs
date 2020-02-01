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
            pi.tower1Repaired = true;
            tower.GetComponent<FixTower>().Destroy();
            pi.FixAnim.SetBool("Repair", true);
            pi.Invoke("RemoveFix", 2f);
        } else if (puzzleNo == 2)
        {
            pi.tower2Repaired = true;
            tower.GetComponent<FixTower>().Destroy();
            pi.FixAnim.SetBool("Repair", true);
            pi.Invoke("RemoveFix", 2f);
        } else if (puzzleNo == 3)
        {
            pi.tower3Repaired = true;
            tower.GetComponent<FixTower>().Destroy();
            pi.FixAnim.SetBool("Repair", true);
            pi.Invoke("RemoveFix", 2f);
        }

        puzzleStarter.SetActive(false);
        puzzle.SetActive(false);
        player.SetActive(true);
    }
}
