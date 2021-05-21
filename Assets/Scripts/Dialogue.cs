using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dialogue : MonoBehaviour
{

    [SerializeField]
    GameObject dialogueBox, nPC1Btn, nPC2Btn;

    DialogueObj dialogueScriptableObj;

    [SerializeField]
    Image leftSpeaker, rightSpeaker;

    [SerializeField]
    List<GameObject> nPCS = new List<GameObject>();

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

    void CloseDialogueBox()
    {
        dialogueBox.SetActive(false);
        diaText.text = string.Empty;
        nPC1Btn.SetActive(true);
        nPC2Btn.SetActive(true);
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
            //yield return new WaitUntil(() => Input.touchCount > 0); use this once we test on android
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.S));
        }

        CloseDialogueBox();
    }

    public void InteractWithNPC1()
    {
        if (nPC1Btn.activeInHierarchy)
        {
            dialogueScriptableObj = nPCS[0].GetComponent<DialogueInteractable>().myDialogueScriptableObj;
            ShowDialogue(dialogueScriptableObj);
            SetSpeaker();
            nPC2Btn.SetActive(false);
        }
    }

    public void InteractWithNPC2()
    {
        if (nPC2Btn.activeInHierarchy)
        {
            dialogueScriptableObj = nPCS[1].GetComponent<DialogueInteractable>().myDialogueScriptableObj;
            ShowDialogue(dialogueScriptableObj);
            SetSpeaker();
            nPC1Btn.SetActive(false);
        }
    }
}
