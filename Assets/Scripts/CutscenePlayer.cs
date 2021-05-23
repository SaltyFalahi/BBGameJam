using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutscenePlayer : MonoBehaviour
{
    public Animator anim;

    public Dialogue dialogue;

    public string trigger;
    public string sceneName;

    public float timer;

    public bool condition;

    float countdown;

    bool played;

    // Start is called before the first frame update
    void Start()
    {
        countdown = timer;
    }

    // Update is called once per frame
    void Update()
    {
        if (condition)
        {
            Debug.Log("Condition");
            anim.SetTrigger(trigger);
            played = true;
            condition = false;
        }

        if (countdown <= 0)
        {
            Debug.Log("Played");
            dialogue.Begin();
            played = false;
            countdown = timer;
        }
        else if (played)
        {
            countdown -= Time.deltaTime;
        }

        if (dialogue.done)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
