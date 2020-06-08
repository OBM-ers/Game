using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBarSliderOBM : MonoBehaviour
{
    //Slider component
    public Slider sliderOBM;

    public void SetMaxEnergyOBM(int a_energyBarOBM)
    {
        //Set slider values to set max health (from PlayerHud script)
        sliderOBM.maxValue = a_energyBarOBM;
        sliderOBM.value = a_energyBarOBM;
    }

    public void SetEnergyOBM(int a_energyBarOBM)
    {
        //Set slider values to set health (from PlayerHud script)
        sliderOBM.value = a_energyBarOBM;
    }
}
