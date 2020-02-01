﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator animator;
    private CharacterController characterController;
    private List<string> inventory = new List<string>();
    private GameObject targeted;

    public Transform pivot;
    //public Transform pivot2;

    //public Transform playerModel;
    //public GameObject gunSpawnPoint;
    //public GameObject player;

    public float CharacterSpeed;
    public float gravity;
    public float rotateSpeed = 10;
    private Vector3 moveDirection;

    float v;
    float h;

    float mv;
    float mh;

    private void Start() {
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
    }

    void Update() {
        mv -= Input.GetAxis("Mouse Y") * 10;
        mh += Input.GetAxis("Mouse X") * 10;

        v = Input.GetAxis("Vertical");
        h = Input.GetAxis("Horizontal");

        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            CharacterSpeed = 2;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            CharacterSpeed = 1;
        }

        if (targeted != null
                && targeted.GetComponent<PickupableObject>() != null
                && Input.GetKeyDown(KeyCode.E)) {
            Debug.Log("Picking up");
            inventory.Add(targeted.name);
            targeted.SetActive(false);
            targeted = null;
        }

        if (Input.GetKeyDown(KeyCode.Tab)) {
            Debug.Log("Inventory:");
            inventory.ForEach(item => Debug.Log(item));
        }

        if (targeted != null
                && targeted.GetComponent<InteractableObject>() != null
                && Input.GetKeyDown(KeyCode.R)) {
            Debug.Log("Repairing");
            InteractableObject interactable = targeted.GetComponent<InteractableObject>();

            if (!interactable.repaired
                    && inventory.Contains(interactable.neededItem)) {
                interactable.Repair();
            }
        }

        //animations setup
        //if ((((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)))))
        //{
        //    animator.SetBool("isWalking", true);
        //} else
        //{
        //    animator.SetBool("isWalking", false);
        //}

        //if(Input.GetMouseButton(1))
        //{
        //    animator.SetBool("PullGun", true);
        //    transform.rotation = pivot2.transform.rotation;
        //}

        //if (Input.GetMouseButtonUp(1))
        //{
        //    animator.SetBool("PullGun", false);
        //}


        //calculating direction based on which key is pressed (ws - vertically, ad - horizontally)
        //normalizaing the direction when 2 keys are pressed, gravity and saying move the player in that
        //calculated direction
        moveDirection = (transform.forward * v) + (transform.right * h);
        moveDirection = moveDirection.normalized * CharacterSpeed;
        moveDirection.y -= gravity * Time.deltaTime;
        characterController.Move(moveDirection * Time.deltaTime);


        //calculating if there is input from the user and if there is than rotate the player in the
        //direction of the camera and making the player look at the direction of the new rotation which is
        //set by user input (wasd), and smoothing that rotation of the player on the line 57
        if((v != 0) || (h != 0))
        {
            transform.rotation = pivot.transform.rotation;
            Quaternion newRotation = Quaternion.LookRotation(new Vector3(moveDirection.x, 0f, moveDirection.z));
            //playerModel.transform.rotation = Quaternion.Slerp(playerModel.transform.rotation, newRotation, rotateSpeed * Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider trigger) {
       Debug.Log("Triggered");

       if (trigger.GetComponent<PickupableObject>() != null
               && trigger.GetComponent<PickupableObject>().pickupable) {
           Debug.Log("Pickupable");
           targeted = trigger.gameObject;
        }

       if (trigger.GetComponent<InteractableObject>() != null
               && !trigger.GetComponent<InteractableObject>().repaired) {
           Debug.Log("Interactable");
           targeted = trigger.gameObject;
       }
    }
}