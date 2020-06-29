using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class ControllerDriver : MonoBehaviour
{
    SerialPort ControllerDataObm;
    //Controller variables
    public bool controllerEnabledObm = false;
    public string controllerInputObm;    
    public bool jumpInputObm;
    public bool attackInputObm;

    void Awake()
    {
        try
        {
            //Tries to open the serialport to com4, baudrate 115200
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
                //same as before but this is made to reopen the communication with the serialport after loading a scene
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
        else 
        {
            try
            {
                //Input to right with joystick
                if (ControllerDataObm.ReadLine() == "1")
                {
                    controllerInputObm = "1";
                }
                //Input to left with joystick
                else if (ControllerDataObm.ReadLine() == "-1")
                {
                    controllerInputObm = "-1";
                }
                //Input forward with joystick
                else if (ControllerDataObm.ReadLine() == "2")
                {
                    controllerInputObm = "2";
                }
                //Jump input with jumpbutton
                else if (ControllerDataObm.ReadLine() == "5")
                {

                    jumpInputObm = true;
                    Debug.Log(controllerInputObm);
                }
                //Attack input with attackbutton
                else if (ControllerDataObm.ReadLine() == "6")
                {
                    attackInputObm = true;
                }
                //is the idle state
                else if (ControllerDataObm.ReadLine() == "0")
                {
                    controllerInputObm = "0";
                }
            }
            catch { }
        }
    }
}
