using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Interactable : MonoBehaviour
{
    public bool interacting;

    Interactor interactor;

    //Called by the interact button
    public void Interact()
    {
        interacting = true;
    }

    //Override in child class to do what you need
    //interacting needs to be set to false in the end
    public virtual void InteractAction()
    {
        interacting = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Interactor"))
        {
            interactor = collision.GetComponent<Interactor>();
            interactor.GetInteractable(this);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Interactor"))
        {
            interactor.RemoveInteractable();
            interactor = null;
        }
    }
}
