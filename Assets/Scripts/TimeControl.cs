using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeControl : MonoBehaviour
{
    public Animator anim;

    public DisplayTimer displayTimer;

    public float slowSpeed = 10;
    public float fastSpeed = 2.5f;

    float daySpeed;

    bool slowTime;
    bool fastTime;

    // Start is called before the first frame update
    void Start()
    {
        daySpeed = displayTimer.daySpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (slowTime)
        {
            displayTimer.daySpeed = slowSpeed;
        }
        else if (fastTime)
        {
            displayTimer.daySpeed = fastSpeed;
        }
        else
        {
            displayTimer.daySpeed = daySpeed;
        }
    }

    public void SlowTime()
    {
        slowTime = true;
        fastTime = false;
        CloseTimeMenu();
    }

    public void FastTime()
    {
        fastTime = true;
        slowTime = false;
        CloseTimeMenu();
    }

    public void RegularTime()
    {
        fastTime = false;
        slowTime = false;
        CloseTimeMenu();
    }

    public void OpenTimeMenu()
    {
        anim.SetTrigger("OpenMenu");
    }

    public void CloseTimeMenu()
    {
        anim.SetTrigger("CloseMenu");
    }
}
