using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[System.Serializable]
public class ItemInteractable : Interactable
{
    public GameObject textObj;
    public GameObject mainObj;

    public TMP_Text textDisplay;

    public string description;

    public override void InteractAction()
    {
        mainObj.SetActive(false);
        textObj.SetActive(true);
        textDisplay.text = description;
        interacting = false;
    }
}
