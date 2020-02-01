using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    //third person controller
    public float mouseSensitivity = 10f;
    private float mouseX;
    private float mouseY;

    public Transform target;
    public Transform player;
    public Transform pivot;
    //public Transform pivot2;

    public float distanceFromTarget;
    public float rotationSmoothTime = 5f;

    Vector3 rotationSmoothVelocity;
    Vector3 currentRotation;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void LateUpdate()
    {
        if (true) {//player.GetComponent<PlayerController>().movementEnabled) {
            //pivot setup
            pivot.transform.position = player.transform.position;

            mouseX += Input.GetAxis("Mouse X") * mouseSensitivity;
            mouseY -= Input.GetAxis("Mouse Y") * mouseSensitivity;
            mouseY = Mathf.Clamp(mouseY, -35, 60);

            currentRotation = Vector3.SmoothDamp(currentRotation, new Vector3(mouseY, mouseX), ref rotationSmoothVelocity, rotationSmoothTime);

            pivot.rotation = Quaternion.Euler(0, mouseX , 0);
            //pivot2.rotation = Quaternion.Euler(0, mouseX, 0);

            transform.position = target.position - transform.forward * distanceFromTarget;
            transform.eulerAngles = currentRotation;
        }
    }
}
