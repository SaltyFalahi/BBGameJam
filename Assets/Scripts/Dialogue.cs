using System.Collections;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    [SerializeField]
    GameObject dialogueBox;
    [SerializeField]
    TMP_Text diaText;
    [SerializeField]
    DialogueObj testDia;

    TypewriterFX typewriterFX;

    // Start is called before the first frame update
    void Start()
    {
        typewriterFX = GetComponent<TypewriterFX>();
        CloseDialogueBox();
        ShowDialogue(testDia);
    }

    public void ShowDialogue(DialogueObj dialogueObj)
    {
        dialogueBox.SetActive(true);
        StartCoroutine(StepThroughDialogue(dialogueObj));
    }

    IEnumerator StepThroughDialogue(DialogueObj dialogueObj)
    {
        foreach (Lines dialogue in dialogueObj.dialogueArr)
        {
            yield return typewriterFX.Run(dialogue.text, diaText);
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        }

        CloseDialogueBox();
    }

    void CloseDialogueBox()
    {
        dialogueBox.SetActive(false);
        diaText.text = string.Empty;
    }
}
