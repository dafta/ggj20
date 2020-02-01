using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupItems : MonoBehaviour
{
    [Header("Objects")]
    public GameObject gasTank;
    public GameObject screwDriver;
    public GameObject propeler;

    [Header("Text References")]
    public Text pickUpText;

    private void Start()
    {
        gasTank.SetActive(true);
    }

    public void OnTriggerStay(Collider other)
    {
        if(other.tag == "GasTank")
        {
            pickUpText.text = "Press 'E' to pick up gas carnister";
            if(Input.GetKey(KeyCode.E))
            {
                gasTank.SetActive(false);
                pickUpText.text = "";
            }
        }

        if (other.tag == "Propeler")
        {
            pickUpText.text = "Press 'E' to pick up wing";
            if (Input.GetKey(KeyCode.E))
            {
                propeler.SetActive(false);
                pickUpText.text = "";
            }
        }

        if (other.tag == "Screwdriver")
        {
            pickUpText.text = "Press 'E' to pick up screwdriver";
            if (Input.GetKey(KeyCode.E))
            {
                screwDriver.SetActive(false);
                pickUpText.text = "";
            }
        }
    }
}
