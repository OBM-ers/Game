using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class ControllerDriverObm : MonoBehaviour
{
    SerialPort ControllerDataObm;
    //Controller variables
    public bool controllerEnabledObm = false;
    public string controllerInputObm;    
    public bool jumpInputObm;
    public bool attackInputObm;

    void Awake()
    {
        //string comPortObm = "COM3";
        try
        {
            ControllerDataObm = new SerialPort("COM4", 115200);
            ControllerDataObm.ReadTimeout = 10;
            ControllerDataObm.Open();
            if (ControllerDataObm.IsOpen)
            {
                controllerEnabledObm = true;
            }
        }
        catch { }
    }

    // Update is called once per frame
    void Update()
    {
        if(controllerEnabledObm == false)
        {
            try
            {
                ControllerDataObm = new SerialPort("COM4", 115200);
                ControllerDataObm.ReadTimeout = 10;
                ControllerDataObm.Open();
                if (ControllerDataObm.IsOpen)
                {
                    controllerEnabledObm = true;
                }
            }
            catch { }
        }
        else {
            try
            {
                if (ControllerDataObm.ReadLine() == "1")
                {

                    // Debug.Log(controllerInputObm);
                    controllerInputObm = "1";
                }

                else if (ControllerDataObm.ReadLine() == "-1")
                {
                    //Debug.Log(controllerInputObm);
                    controllerInputObm = "-1";
                }
                else if (ControllerDataObm.ReadLine() == "2")
                {
                    //Debug.Log(controllerInputObm);
                    controllerInputObm = "2";
                }
                else if (ControllerDataObm.ReadLine() == "5")
                {

                    jumpInputObm = true;
                    Debug.Log(controllerInputObm);
                }
                else if (ControllerDataObm.ReadLine() == "6")
                {
                    attackInputObm = true;
                   // controllerInputObm = "6";
                    // Debug.Log(controllerInputObm);
                }
                else if (ControllerDataObm.ReadLine() == "0")
                {
                    controllerInputObm = "0";
                    //Debug.Log(controllerInputObm);
                }
            }
            catch { }
        }
    }
}
