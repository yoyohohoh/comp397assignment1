using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomSave : MonoBehaviour
{
    
   //PlayerController playerController;

    private void Start()
    {
        //playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }
    private void OnCollisionEnter(Collision other)
    {
       //playerController.InitialPosition();
    }
}
