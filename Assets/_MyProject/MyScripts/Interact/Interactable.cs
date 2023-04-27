using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using TMPro;

public class Interactable : MonoBehaviour
{
    //message displayed to player when looking at an interactable
    [HideInInspector]
    public string prompMessage;
  

    public void BaseInteract()
    {
        Interact();
    }

    public virtual void Interact()
    {
        //we wont have any code written in this function
        //this is aa template function to be overridden by our sbclasses
    }

}