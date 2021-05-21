using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TypewriterFX : MonoBehaviour
{
    [SerializeField]
    float typeSpeed = 0;
    public Coroutine Run(string textToType, TMP_Text diaText)
    {
        return StartCoroutine(TypeText(textToType, diaText));
    }

    IEnumerator TypeText(string textToType, TMP_Text diaText)
    {
        float t = 0;

        int charIndex = 0;

        while(charIndex < textToType.Length)
        {
            t += Time.deltaTime * typeSpeed;

            charIndex = Mathf.FloorToInt(t);
            charIndex = Mathf.Clamp(charIndex, 0, textToType.Length);

            diaText.text = textToType.Substring(0, charIndex);

            if (Input.GetMouseButtonDown(0))
            {
                charIndex = textToType.Length;
            }

            yield return null;
        }

        diaText.text = textToType;
    }
}
