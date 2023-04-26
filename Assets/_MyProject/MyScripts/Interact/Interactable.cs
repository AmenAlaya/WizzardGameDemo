using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using TMPro;

public class Interactable : MonoBehaviour
{
    public bool useEvent;
    //message displayed to player when looking at an interactable
    public string prompMessage;
   
    public TextMeshProUGUI visualMessage;

    public virtual string OnLook()
    {
        return prompMessage;
    }

    public void BaseInteract()
    {
        Interact();
    }

    protected virtual void Interact()
    {
        //we wont have any code written in this function
        //this is aa template function to be overridden by our sbclasses
    }

    protected virtual void ShowSelected() 
    {

    }
}