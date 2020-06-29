using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBarSlider : MonoBehaviour
{
    //Slider component
    public Slider sliderObm;

    public void SetMaxEnergyObm(int a_energyBarObm)
    {
        //Set slider values to set max health (from PlayerHud script)
        sliderObm.maxValue = a_energyBarObm;
        sliderObm.value = a_energyBarObm;
    }

    public void SetEnergyObm(int a_energyBarObm)
    {
        //Set slider values to set health (from PlayerHud script)
        sliderObm.value = a_energyBarObm;
    }
}
