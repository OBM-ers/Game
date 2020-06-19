using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class TimerOBM : MonoBehaviour
{
    public Text timerTextOBM;

    private float startTimeOBM = 0f;
    private float actualTimeTakenOBM = 0f;

    // Start is called before the first frame update
    void Start()
    {
        startTimeOBM = Time.timeSinceLevelLoad;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        actualTimeTakenOBM = startTimeOBM + Time.timeSinceLevelLoad;

        string minutesOBM = ((int)actualTimeTakenOBM / 60).ToString("00");
        string secondsOBM = (actualTimeTakenOBM % 60).ToString("f2");

        secondsOBM = secondsOBM.Replace(',', ':');

        if (secondsOBM.Length != 5)
        {
            timerTextOBM.text = minutesOBM + ":0" + secondsOBM;
        }
        else
        {
            timerTextOBM.text = minutesOBM + ":" + secondsOBM;
        }
    }

    public void RestartTimerObm()
    {
        startTimeOBM = Time.timeSinceLevelLoad;
    }
}
