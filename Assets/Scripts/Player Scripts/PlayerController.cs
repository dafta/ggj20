using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Transform pivot;
    //public Transform pivot2;

    //public Transform playerModel;
    //public GameObject gunSpawnPoint;
    //public GameObject player;

    public float CharacterSpeed;
    public float gravity;
    public float rotateSpeed = 10;
    public bool movementEnabled = true;
    public ThirdPersonCamera camera;

    private Vector3 moveDirection;
    private Animator animator;
    private CharacterController characterController;
    private GameObject targeted;

    private List<string> inventory = new List<string>();

    float v;
    float h;

    float mv;
    float mh;

    private void Start() {
        float x =PlayerPrefs.GetFloat("X", transform.position.x);
        float y =PlayerPrefs.GetFloat("Y", transform.position.y);
        float z =PlayerPrefs.GetFloat("Z", transform.position.z);

        transform.position = new Vector3(x, y, z);

        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
    }

    void Update() {
        if (movementEnabled) {
            mv -= Input.GetAxis("Mouse Y") * 10;
            mh += Input.GetAxis("Mouse X") * 10;

            v = Input.GetAxis("Vertical");
            h = Input.GetAxis("Horizontal");

            if(Input.GetKeyDown(KeyCode.LeftShift))
            {
                CharacterSpeed = 7;
            }

            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                CharacterSpeed = 5;
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
                    inventory.Remove(interactable.neededItem);
                    interactable.Repair();
                }
            }

            if (Input.GetKeyDown(KeyCode.Escape)) {
                PlayerPrefs.SetFloat("X", transform.position.x);
                PlayerPrefs.SetFloat("Y", transform.position.y);
                PlayerPrefs.SetFloat("Z", transform.position.z);

                Cursor.lockState = CursorLockMode.None;
                SceneManager.LoadScene("MainMenu");
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

        if (Input.GetKeyDown(KeyCode.F)) {
            if (movementEnabled) {
                movementEnabled = !movementEnabled;
                Cursor.lockState = CursorLockMode.None;
                camera.enabled = false;
            } else {
                movementEnabled = !movementEnabled;
                Cursor.lockState = CursorLockMode.Locked;
                camera.enabled = true;
            }
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
