using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "GameDialogues/DialogueObj")]
public class DialogueObj : ScriptableObject
{
    public Lines[] dialogueArr;

    public Sprite LeftSpeaker;
    public Sprite RightSpeaker;
}

[System.Serializable]
public class Lines
{
    public bool isLeftSpeaker;

    [TextArea(2, 10)]
    public string text;
}
