using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public string neededItem;
    public bool repaired = false;
    public GameObject fixedObject;
    public GameObject brokenObject;

    // Start is called before the first frame update
    void Start() {
        fixedObject.SetActive(false);
    }

    // Update is called once per frame
    void Update() {

    }

    public void Repair() {
        Debug.Log("Repairing");
        fixedObject.SetActive(true);
        brokenObject.SetActive(false);
    }
}
