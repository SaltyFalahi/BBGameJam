using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Interactable : MonoBehaviour
{
    public bool interacting;

    //Called by the interact button
    public void Interact()
    {
        interacting = true;
    }

    //Override in child class to do what you need
    //interacting needs to be set to false in the end
    public virtual void InteractAction()
    {
        Debug.Log("Working");
        interacting = false;
    }
}
