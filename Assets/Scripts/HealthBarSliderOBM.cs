using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarSliderOBM : MonoBehaviour
{
    //Slider component
    public Slider sliderOBM;

    public void SetMaxHealthOBM(int a_healthBarOBM)
    {
        //Set slider values to set max health (from PlayerHud script)
        sliderOBM.maxValue = a_healthBarOBM;
        sliderOBM.value = a_healthBarOBM;
    }

    public void SetHealthOBM(int a_healthBarOBM)
    {
        //Set slider values to set health (from PlayerHud script)
        sliderOBM.value = a_healthBarOBM;
    }
}
