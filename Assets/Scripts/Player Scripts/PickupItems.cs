using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupItems : MonoBehaviour
{
    public int fixedStation = 0;
    public int counter = 0;

    public GameObject panel;
    public GameObject sipanje;
    public GameObject serafanjeAnim;

    public GameObject endGame;

    [Header("Objects")]
    public GameObject gasTank;
    public GameObject kriloOtpalo;
    public GameObject screwDriver;
    public GameObject propeler;

    public GameObject Helipropeler;

    public GameObject walkieTalkie;

    public GameObject rotor;
    public GameObject zadnjiKraj2;

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
    public GameObject zadnjiKraj;


    [Header("Inventory")]
    public int wing = 0;
    public int gas = 0;
    public int screwdriver = 0;
    public int elisa = 0;

    [Header("Tower Status")]
    public int tutorialStatus = 0;
    public int tower1Status = 0;
    public int tower2Status = 0;
    public int tower3Status = 0;

    [Header("bools for turn on/off text")]
    public bool wingIsRepaired = false;
    public bool gasIsRepaired = false;

    [Header("Animations")]
    public Animator pickupAnim;
    public Animator FixAnim;
    public Animator walkieAnim;

    [Header("Press to grab... icons")]
    public GameObject screwdriverPNG;
    public GameObject fuelPNG;
    public GameObject propelerPNG;  //wingPNG
    public GameObject rotorPNG;

    [Header("Player")]
    public GameObject player;

    [Header("Towers")]
    public GameObject tower1;
    public GameObject tower2;
    public GameObject tower3;

    [Header("Puzzles")]
    public GameObject puzzleTutorial;
    public GameObject puzzle1;
    public GameObject puzzle2;
    public GameObject puzzle3;

    [Header("Objects")]
    public AudioSource captureTower;
    public AudioSource pickupItem;

    public AudioSource talking;
    public AudioSource talking2;
    public AudioSource talking3;

    public AudioSource repairSound;

    public GameObject kriloMinimap;

    public bool idk = false;

    private void Start()
    {
        Helipropeler.SetActive(false);
        endGame.SetActive(false);

        wing = PlayerPrefs.GetInt("wing", 0);
        gas = PlayerPrefs.GetInt("gas", 0);
        screwdriver = PlayerPrefs.GetInt("screwdriver", 0);
        elisa = PlayerPrefs.GetInt("elisa", 0);

        tutorialStatus = PlayerPrefs.GetInt("tutorialStatus", 0);

        tower1Status = PlayerPrefs.GetInt("tower1Status", 0);
        tower2Status = PlayerPrefs.GetInt("tower2Status", 0);
        tower3Status = PlayerPrefs.GetInt("tower3Status", 0);

        fixedStation = PlayerPrefs.GetInt("fixedStation", 0);

        counter = PlayerPrefs.GetInt("counter", 0);

        if (wing >= 1) {
            propeler.SetActive(false);
            tick2.SetActive(true);

            if (wing >= 2) {
                rotor.SetActive(true);
                propelerIcon.SetActive(false);
            }
        }

        if (gas >= 1) {
            gasTank.SetActive(false);
            tick1.SetActive(true);

            if (gas >= 2) {
                fuelIcon.SetActive(false);
            }
        }

        if (screwdriver >= 1) {
            screwDriver.SetActive(false);
            tick.SetActive(true);

            if (screwdriver >= 2) {
                screwdriverIcon.SetActive(false);
            }
        }

        if (elisa >= 1) {
            kriloOtpalo.SetActive(false);
            tick3.SetActive(true);

            if (elisa >= 2) {
                zadnjiKraj2.SetActive(true);
                zadnjiKraj.SetActive(false);
            }
        }

        if (tower1Status >= 1) {
            tower1.GetComponent<FixTower>().Destroy();
        }

        if (tower2Status >= 1) {
            tower2.GetComponent<FixTower>().Destroy();
        }

        if (tower3Status >= 1) {
            tower3.GetComponent<FixTower>().Destroy();
        }
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

        if(counter >= 7)
        {
            //upali sliku sa objectivom "get of the island"
            endGame.SetActive(true);
        }

        if (fixedStation == 3) {
            if (Input.GetMouseButtonDown(1)) {
                fixedStation = 4;
                StartCoroutine(Talk());
            }
        }

        if(Input.GetKeyDown(KeyCode.I))
        {
            talking.Play();
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            talking2.Play();
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            talking3.Play();
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
                gas = 1;
                tick1.SetActive(true);

                PlayerPrefs.SetInt("gas", gas);

                Destroy(fuelPNG);

                pickupAnim.SetBool("Pickup", true);
                Invoke("RemoveArm", 0.50f);

                pickupItem.Play();
            }
        }

        if (other.tag == "Propeler")
        {
            rotorPNG.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                propeler.SetActive(false);
                wing = 1;
                tick2.SetActive(true);

                PlayerPrefs.SetInt("wing", wing);

                Destroy(rotorPNG);

                pickupAnim.SetBool("Pickup", true);
                Invoke("RemoveArm", 0.50f);
                pickupItem.Play();
            }
        }

        if (other.tag == "Screwdriver")
        {
            screwdriverPNG.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                screwDriver.SetActive(false);
                screwdriver = 1;
                tick.SetActive(true);

                PlayerPrefs.SetInt("screwdriver", screwdriver);

                Destroy(screwdriverPNG);

                pickupAnim.SetBool("Pickup", true);
                Invoke("RemoveArm", 0.50f);
                pickupItem.Play();
            }
        }

        if (other.tag == "Elisa")
        {
            //fuelPNG - pick up pop up
            propelerPNG.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                kriloOtpalo.SetActive(false);
                kriloMinimap.SetActive(false);
                elisa = 1;
                tick3.SetActive(true);

                PlayerPrefs.SetInt("elisa", elisa);

                Destroy(propelerPNG);

                pickupAnim.SetBool("Pickup", true);
                Invoke("RemoveArm", 0.50f);
                pickupItem.Play();
            }
        }



        //Triggeri za repair
        if (other.tag == "RepairRotor")
        {
            if(wing == 1)
            {
                rotor.SetActive(true);
                propelerIcon.SetActive(false);
                counter++;
                wing = 2;

                PlayerPrefs.SetInt("counter", counter);
                PlayerPrefs.SetInt("wing", wing);

                repairSound.Play();
            }
        }

        if (other.tag == "RepairZadnjiKraj")
        {
            if (elisa == 1)
            {
                zadnjiKraj2.SetActive(true);
                zadnjiKraj.SetActive(false);
                counter++;
                elisa = 2;

                PlayerPrefs.SetInt("counter", counter);
                PlayerPrefs.SetInt("elisa", elisa);

                repairSound.Play();
            }
        }

        if (other.tag == "FillGas")
        {
            if (gas == 1)
            {
                //optional - animacija sipanja goriva (ako stignem)
                sipanje.SetActive(true);
                Invoke("DeleteGasAnimation", 4.3f);
                fuelIcon.SetActive(false);
                counter++;
                gas = 2;

                PlayerPrefs.SetInt("counter", counter);
                PlayerPrefs.SetInt("gas", gas);

                repairSound.Play();
            }
        }

        if (other.tag == "Serafanje")
        {
            if (screwdriver == 1)
            {
                serafanjeAnim.SetActive(true);
                Invoke("DeleteSerafanjeAnim", 4.35f);
                screwdriverIcon.SetActive(false);
                counter++;
                screwdriver = 2;


                PlayerPrefs.SetInt("counter", counter);
                PlayerPrefs.SetInt("screwdriver", screwdriver);

                repairSound.Play();
            }
        }



        if (other.tag == "RadioTrigger1")
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                player.SetActive(false);
                puzzle1.SetActive(true);
                captureTower.Play();
                repairSound.Play();
            }
        }

        if(other.tag == "RadioTrigger2")
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                player.SetActive(false);
                puzzle2.SetActive(true);
                captureTower.Play();
                repairSound.Play();
            }
        }

        if(other.tag == "RadioTrigger3")
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                player.SetActive(false);
                puzzle3.SetActive(true);
                captureTower.Play();
                repairSound.Play();
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

    public void DeleteGasAnimation()
    {
        sipanje.SetActive(false);
    }

    public void DeleteSerafanjeAnim()
    {
        serafanjeAnim.SetActive(false);
    }

    IEnumerator Talk() {
        yield return new WaitForSeconds(1);
        talking.Play();
        yield return new WaitForSeconds(4);
        talking2.Play();
        yield return new WaitForSeconds(9);
        talking3.Play();
    }

    public void PlayDialogue()
    {
        talking.Play();
    }

    public void PlayDialogue2()
    {
        talking2.Play();
    }

    public void PlayDialogue3()
    {
        talking3.Play();
    }
}
