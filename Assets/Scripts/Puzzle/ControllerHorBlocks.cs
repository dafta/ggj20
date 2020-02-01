using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerHorBlocks : MonoBehaviour
{
    public GameObject hor;
    public float sensitivity;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            hor.GetComponent<Rigidbody>().velocity += new Vector3(0, 0, sensitivity);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            hor.GetComponent<Rigidbody>().velocity -= new Vector3(0, 0, sensitivity);
        }
    }
}
