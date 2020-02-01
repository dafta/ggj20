using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupItems : MonoBehaviour
{
    public GameObject panel;

    [Header("Objects")]
    public GameObject gasTank;
    public GameObject kriloOtpalo;
    public GameObject screwDriver;
    public GameObject propeler;

    public GameObject Helipropeler;

    public GameObject walkieTalkie;

    [Header("Text References")]
    public Text pickUpText;
    public Text repairText;

    [Header("Tick References")]
    public GameObject tick;
    public GameObject tick1;
    public GameObject tick2;
    public GameObject tick3;

    [Header("Icons References")]
    public GameObject screwdriverIcon;
    public GameObject fuelIcon;
    public GameObject propelerIcon;


    [Header("Inventory")]
    public bool wing = false;
    public bool gas = false;
    public bool screwdriver = false;
    public bool elisa = false;

    [Header("bools for turn on/off text")]
    public bool wingIsRepaired = false;
    public bool gasIsRepaired = false;

    public bool tower1Repaired = false;
    public bool tower2Repaired = false;
    public bool tower3Repaired = false;

    [Header("Animations")]
    public Animator pickupAnim;
    public Animator FixAnim;
    public Animator walkieAnim;

    [Header("Press to grab... icons")]
    public GameObject screwdriverPNG;
    public GameObject fuelPNG;
    public GameObject propelerPNG;  //wingPNG
    //public GameObject rotorPNG;

    [Header("Player")]
    public GameObject player;

    [Header("Puzzles")]
    public GameObject puzzleTutorial;
    public GameObject puzzle1;
    public GameObject puzzle2;
    public GameObject puzzle3;

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

        if (Input.GetMouseButton(1))
        {
            walkieTalkie.SetActive(true);
            walkieAnim.SetBool("HoldingWalkie", true);
        }

        if (Input.GetMouseButtonUp(1))
        {
            walkieTalkie.SetActive(false);
            walkieAnim.SetBool("HoldingWalkie", false);
        }
    }

    public void OnTriggerStay(Collider other)
    {

        //Triggeri za Pick up
        if(other.tag == "GasTank")
        {
            //fuelPNG - pick up pop up
            fuelPNG.SetActive(true);
            if(Input.GetKey(KeyCode.E))
            {
                gasTank.SetActive(false);
                gas = true;
                tick1.SetActive(true);

                Destroy(fuelPNG);

                pickupAnim.SetBool("Pickup", true);
                Invoke("RemoveArm", 0.50f);
            }
        }

        if (other.tag == "Propeler")
        {
            propelerPNG.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                propeler.SetActive(false);
                wing = true;
                tick2.SetActive(true);

                Destroy(propelerPNG);

                pickupAnim.SetBool("Pickup", true);
                Invoke("RemoveArm", 0.50f);
            }
        }

        if (other.tag == "Screwdriver")
        {
            screwdriverPNG.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                screwDriver.SetActive(false);
                screwdriver = true;
                tick.SetActive(true);

                Destroy(screwdriverPNG);

                pickupAnim.SetBool("Pickup", true);
                Invoke("RemoveArm", 0.50f);
            }
        }

        if (other.tag == "Elisa")
        {
            //fuelPNG - pick up pop up
            propelerPNG.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                kriloOtpalo.SetActive(false);
                elisa = true;
                tick3.SetActive(true);

                Destroy(propelerPNG);

                pickupAnim.SetBool("Pickup", true);
                Invoke("RemoveArm", 0.50f);
            }
        }



        //Triggeri za repair
        if (other.tag == "RepairWing")
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

        if(other.tag == "RadioTrigger1")
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                player.SetActive(false);
                puzzle1.SetActive(true);
            }
        }

        if(other.tag == "RadioTrigger2")
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                player.SetActive(false);
                puzzle2.SetActive(true);
            }
        }

        if(other.tag == "RadioTrigger3")
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                player.SetActive(false);
                puzzle3.SetActive(true);
            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        screwdriverPNG.SetActive(false);
        fuelPNG.SetActive(false);
        propelerPNG.SetActive(false);
    }

    public void RemoveArm()
    {
        pickupAnim.SetBool("Pickup", false);
    }

    public void RemoveFix()
    {
        FixAnim.SetBool("Repair", false);
    }
}
