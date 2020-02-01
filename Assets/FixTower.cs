using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FixTower : MonoBehaviour
{
    public PickupItems pickupScript;

    public GameObject fixRadio;

    public GameObject radioTowerCheck;

    private void OnTriggerEnter(Collider other)
    {
        fixRadio.SetActive(true);
        //Invoke("Destroy", 3f);
    }

    private void OnTriggerExit(Collider other)
    {
        fixRadio.SetActive(false);
    }

    public void Destroy()
    {
        Destroy(fixRadio);
        radioTowerCheck.SetActive(true);
    }
}
