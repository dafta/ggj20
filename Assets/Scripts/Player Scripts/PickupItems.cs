using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupItems : MonoBehaviour
{
    public GameObject panel;

    [Header("Objects")]
    public GameObject gasTank;
    public GameObject screwDriver;
    public GameObject propeler;

    public GameObject Helipropeler;

    [Header("Text References")]
    public Text pickUpText;
    public Text repairText;

    [Header("Tick References")]
    public GameObject tick;
    public GameObject tick1;
    public GameObject tick2;

    [Header("Icons References")]
    public GameObject screwdriverIcon;
    public GameObject fuelIcon;
    public GameObject propelerIcon;


    [Header("Inventory")]
    public bool wing = false;
    public bool gas = false;
    public bool screwdriver = false;

    [Header("bools for turn on/off text")]
    public bool wingIsRepaired = false;
    public bool gasIsRepaired = false;

    private void Start()
    {
        gasTank.SetActive(true);
        Helipropeler.SetActive(false);
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.Tab))
        {
            panel.SetActive(true);
        }

        if (Input.GetKeyUp(KeyCode.Tab))
        {
            panel.SetActive(false);
        }
    }

    public void OnTriggerStay(Collider other)
    {

        //Triggeri za Pick up
        if(other.tag == "GasTank")
        {
            pickUpText.text = "Press 'E' to pick up gas carnister";
            if(Input.GetKey(KeyCode.E))
            {
                gasTank.SetActive(false);
                gas = true;
                tick1.SetActive(true);
                pickUpText.text = "";
            }
        }

        if (other.tag == "Propeler")
        {
            pickUpText.text = "Press 'E' to pick up wing";
            if (Input.GetKey(KeyCode.E))
            {
                propeler.SetActive(false);
                wing = true;
                tick2.SetActive(true);
                pickUpText.text = "";
            }
        }

        if (other.tag == "Screwdriver")
        {
            pickUpText.text = "Press 'E' to pick up screwdriver";
            if (Input.GetKey(KeyCode.E))
            {
                screwDriver.SetActive(false);
                screwdriver = true;
                tick.SetActive(true);
                pickUpText.text = "";
            }
        }

        

        //Triggeri za repair
        if(other.tag == "RepairWing")
        {
            if(wing == false)
            {
                repairText.text = "You need to find the propeler";
                
            } else
            {
                repairText.text = "Press 'R' to repair wing";

                if(Input.GetKeyDown(KeyCode.R))
                {
                    Helipropeler.SetActive(true);
                    repairText.text = "";
                    wing = false;
                    propelerIcon.SetActive(false);
                    //wing = false;
                }

                //iskljuciti kvacicu za propeler u inventoryu
            } 
        }

        if (other.tag == "PutFuel")
        {
            if (gas == false)
            {
                repairText.text = "You need to find a gas tank";
            }
            else
            {
                repairText.text = "Press 'R' to fill up fuel";
                if (Input.GetKeyDown(KeyCode.R))
                {
                    repairText.text = "";
                    fuelIcon.SetActive(false);
                    //animacija za sipanje goriva
                }

                //iskljuciti kvacicu za gas u inventoryu
            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        pickUpText.text = "";
        repairText.text = "";
    }
}
