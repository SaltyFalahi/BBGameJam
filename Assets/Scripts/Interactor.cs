using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    Interactable interactable;

    public void Interact()
    {
        if (interactable)
        {
            interactable.InteractAction();
        }
    }

    public void GetInteractable(Interactable inter)
    {
        interactable = inter;
    }

    public void RemoveInteractable()
    {
        interactable = null;
    }
}
