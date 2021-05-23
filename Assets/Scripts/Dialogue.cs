using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public bool done;

    [SerializeField]
    GameObject dialogueBox, skipBtn;

    [SerializeField]
    DialogueObj dialogueScriptableObj;

    [SerializeField]
    Image leftSpeaker, rightSpeaker;

    [SerializeField]
    TMP_Text diaText;

    TypewriterFX typewriterFX;

    [SerializeField]
    Color defaultColor, darkColor;

    // Start is called before the first frame update
    void Start()
    {
        typewriterFX = GetComponent<TypewriterFX>();
        CloseDialogueBox();
    }

    public void ShowDialogue(DialogueObj dialogueObj)
    {
        dialogueBox.SetActive(true);
        StartCoroutine(StepThroughDialogue(dialogueObj));
    }

    public void SetSpeaker()
    {
        leftSpeaker.sprite = dialogueScriptableObj.LeftSpeaker;
        rightSpeaker.sprite = dialogueScriptableObj.RightSpeaker;
    }

    public void Begin()
    {
        ShowDialogue(dialogueScriptableObj);
        SetSpeaker();
    }

    void CloseDialogueBox()
    {
        dialogueBox.SetActive(false);
        diaText.text = string.Empty;
        done = true;
    }

    void ChangeSpeaker(int index)
    {
        if (dialogueScriptableObj.dialogueArr[index].isLeftSpeaker)
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
            yield return new WaitUntil(() => Input.touchCount > 0);
            //yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.S));
        }

        CloseDialogueBox();
    }
}
