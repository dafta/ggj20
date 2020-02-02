using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject tutorial;

    void Start()
    {
        tutorial.SetActive(true);
        Invoke("DeleteTutorial", 5f);  
    }
    public void DeleteTutorial()
    {
        tutorial.SetActive(false);
    }

}
