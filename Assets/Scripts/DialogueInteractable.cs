using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueInteractable : Interactable
{
    public DialogueObj myDialogueScriptableObj;
    public Dialogue dialogue;
    public GameObject dialogueBoxObj;
    public GameObject mainMenu;

    public override void InteractAction()
    {
        dialogueBoxObj.SetActive(true);
        mainMenu.SetActive(false);

        dialogue.ShowDialogue(myDialogueScriptableObj);
        dialogue.SetSpeaker();

        interacting = false;
    }
}
