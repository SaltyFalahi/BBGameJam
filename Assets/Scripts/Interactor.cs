using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    Interactable interactable;

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Interactable"))
        {
            interactable = collision.GetComponent<Interactable>();

            if (interactable.interacting)
            {
                interactable.InteractAction();
            }
        }
    }
}
