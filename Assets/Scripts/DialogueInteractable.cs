using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueInteractable : Interactable
{
    public DialogueObj myDialogueScriptableObj;
    public Dialogue dialogue;
    public GameObject dialogueBoxObj;

    public override void InteractAction()
    {
        dialogueBoxObj.SetActive(true);

        dialogue.ShowDialogue(myDialogueScriptableObj);
        dialogue.SetSpeaker();

        interacting = false;
    }
}
