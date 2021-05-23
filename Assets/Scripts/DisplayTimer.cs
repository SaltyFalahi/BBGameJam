using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DisplayTimer : MonoBehaviour
{
    public TMP_Text textTimer;

    public float daySpeed = 5;
    
    public int hoursTimer = 0;

    TimeSO timeSO;

    float timer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        //Convert from hours to minutes
        timer = 60 * hoursTimer;
        timer = timeSO.currentTime;
    }

    // Update is called once per frame
    void Update()
    {
        //Countdown
        timer -= Time.deltaTime / daySpeed;
        DisplayTime();

        //Reset Day
        if (timer <= 0)
        {
            RewindTime();
        }
    }

    void DisplayTime()
    {
        int hours = Mathf.FloorToInt(timer / 60);
        int minutes = Mathf.FloorToInt(timer - hours * 60);
        textTimer.text = string.Format("{0:00}:{1:00}", hours, minutes);
    }

    void RewindTime()
    {
        timer = 60 * hoursTimer;
        timer = timeSO.originalTime;
        SceneManager.LoadScene(0);
    }
}