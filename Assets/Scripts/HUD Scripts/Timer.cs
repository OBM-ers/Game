using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    //Variables
    public Text timerTextObm;
    private float startTimeObm = 0f;
    private float actualTimeTakenObm = 0f;

    // Start is called before the first frame update
    void Start()
    {
        //checks time since scene loaded
        startTimeObm = Time.timeSinceLevelLoad;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Timer
        actualTimeTakenObm = startTimeObm + Time.timeSinceLevelLoad;

        //calculates minutes and seconds. (seconds include millis)
        string minutesObm = ((int)actualTimeTakenObm / 60).ToString("00");
        string secondsObm = (actualTimeTakenObm % 60).ToString("f2");

        secondsObm = secondsObm.Replace(',', ':');

        if (secondsObm.Length != 5)
        {
            timerTextObm.text = minutesObm + ":0" + secondsObm;
        }
        else
        {
            timerTextObm.text = minutesObm + ":" + secondsObm;
        }
    }
}
