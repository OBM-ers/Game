using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarSliderOBM : MonoBehaviour
{
    //Slider component
    public Slider sliderObm;

    public void SetMaxHealthObm(int a_healthBarObm)
    {
        //Set slider values to set max health (from PlayerHud script)
        sliderObm.maxValue = a_healthBarObm;
        sliderObm.value = a_healthBarObm;
    }

    public void SetHealthObm(int a_healthBarObm)
    {
        //Set slider values to set health (from PlayerHud script)
        sliderObm.value = a_healthBarObm;
    }
}
