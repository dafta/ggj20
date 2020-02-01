using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public string neededItem;
    public bool repaired = false;
    public Color repairedColor;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public void Repair() {
        repaired = true;
        MeshRenderer renderer = GetComponent<MeshRenderer>();
        renderer.material.color = repairedColor;
    }
}
