using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dialogue : MonoBehaviour
{
    [SerializeField]
    GameObject dialogueBox;

    [SerializeField]
    Image leftSpeaker, rightSpeaker;

    [SerializeField]
    TMP_Text diaText;
    [SerializeField]
    DialogueObj dialogueObj;

    TypewriterFX typewriterFX;

    [SerializeField]
    Color defaultColor, darkColor;

    // Start is called before the first frame update
    void Start()
    {
        typewriterFX = GetComponent<TypewriterFX>();
        CloseDialogueBox();
        SetSpeaker();
        ShowDialogue(dialogueObj);
    }

    void CloseDialogueBox()
    {
        dialogueBox.SetActive(false);
        diaText.text = string.Empty;
    }

    public void ShowDialogue(DialogueObj dialogueObj)
    {
        dialogueBox.SetActive(true);
        StartCoroutine(StepThroughDialogue(dialogueObj));
    }

    public void SetSpeaker()
    {
        leftSpeaker.sprite = dialogueObj.LeftSpeaker;
        rightSpeaker.sprite = dialogueObj.RightSpeaker;
    }

    void ChangeSpeaker(int index)
    {
        if (dialogueObj.dialogueArr[index].isLeftSpeaker)
        {
            leftSpeaker.color = defaultColor;
            rightSpeaker.color = darkColor;
        }
        else
        {
            leftSpeaker.color = darkColor;
            rightSpeaker.color = defaultColor;
        }
    }

    IEnumerator StepThroughDialogue(DialogueObj dialogueObj)
    {
        int index = 0;

        foreach (Lines dialogue in dialogueObj.dialogueArr)
        {
            ChangeSpeaker(index);
            index++;

            yield return typewriterFX.Run(dialogue.text, diaText);
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        }

        CloseDialogueBox();
    }
}
