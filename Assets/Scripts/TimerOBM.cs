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

    // Start is called before the first frame update
    void Start()
    {
        startTimeObm = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        float actualTimeTakenObm = startTimeObm + Time.time;

        string minutes = ((int)actualTimeTakenObm / 60).ToString("00");
        string seconds = (actualTimeTakenObm % 60).ToString(" f2");
        //string s = seconds.Substring(seconds.Length + 2);
        //string ms = seconds.Substring(seconds.Length - 2);

        seconds = seconds.Replace(',', ':');
        //string s = ;

        if (seconds.Length != 5)
        {
            timerTextObm.text = minutes + " :0 " + seconds;
        }
        else
        {
            timerTextObm.text = minutes + ":" + seconds;
        }
    }
}
