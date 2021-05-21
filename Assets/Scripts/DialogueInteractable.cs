using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueInteractable : Interactable
{
    public DialogueObj myDialogueScriptableObj;
    public GameObject dialogueBoxObj;

    public override void InteractAction()
    {
        dialogueBoxObj.SetActive(true);
        
        interacting = false;
    }
}
