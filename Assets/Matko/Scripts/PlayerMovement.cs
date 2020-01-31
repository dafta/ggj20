using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator animator;
    private CharacterController characterController;

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

    private void Start()
    {
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
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
        //    player.transform.rotation = pivot2.transform.rotation;
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
}

