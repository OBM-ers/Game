using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class TimerOBM : MonoBehaviour
{
    public Text timerTextObm;

    private float startTimeObm = 0;
    //private float actualTimeTakenObm = 0f;

    // Start is called before the first frame update
    void Start()
    {
        startTimeObm = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        float actualTimeTakenObm = Time.time - startTimeObm;

        string minutes = ((int)actualTimeTakenObm / 60).ToString("00");
        string seconds = (actualTimeTakenObm % 60).ToString("f2");
        //string ms = (actualTimeTakenObm * 1000f).ToString("00");

        timerTextObm.text = minutes + ":" + seconds;
        //actualTimeTakenObm += Time.time;
        //timerTextObm.Text = FormatTime(actualTimeTakenObm);
    }

    /*string FormatTime(float time)
    {
        float intTime = (float)time;
        float minutes = intTime / 60;
        float seconds = intTime % 60;
        float fraction = time * 1000;
        fraction = (fraction % 1000);
        string timeText = String.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, fraction);
        return timeText;
    }*/
}
