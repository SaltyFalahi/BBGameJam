using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "GameDialogues/DialogueObj")]
public class DialogueObj : ScriptableObject
{
    public Lines[] dialogueArr;
}

[System.Serializable]
public class Lines
{
    public Sprite image;

    public bool isLeftSpeaker;

    [TextArea(2, 10)]
    public string text;
}
