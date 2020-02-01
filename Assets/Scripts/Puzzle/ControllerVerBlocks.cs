using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerVerBlocks : MonoBehaviour
{
    public float speed;

    // Update is called once per frame
    void Update()
    {
        Rigidbody body = GetComponent<Rigidbody>();
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        body.velocity = new Vector3(h * speed, 0, v * speed);
    }
}