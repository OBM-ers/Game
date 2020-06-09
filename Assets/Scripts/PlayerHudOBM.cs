using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerHudOBM : MonoBehaviour
{
    public int maxValuesOBM = 100;
    public int currentHealthOBM;
    public int currentEnergyOBM;

    private float rechargeTimeOBM = 2;
    public float timerOBM;

    public HealthBarSliderOBM healthBarSliderOBM;
    public EnergyBarSliderOBM energyBarSliderOBM;

    // Start is called before the first frame update
    void Start()
    {
        //Set health and energy
        currentHealthOBM = maxValuesOBM;
        healthBarSliderOBM.SetMaxHealthOBM(maxValuesOBM);

        currentEnergyOBM = maxValuesOBM;
        energyBarSliderOBM.SetMaxEnergyOBM(maxValuesOBM);

        timerOBM = rechargeTimeOBM;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentEnergyOBM != 100)
        {
            timerOBM -= Time.deltaTime;

            if(timerOBM < 0)
            {
                RechargeEnergyOBM(20);
                //reset recharge time to 2 seconds
                timerOBM = rechargeTimeOBM;
            }
        }

        if (Input.GetButtonDown("Fire2"))
        {
            TakeDamageOBM(20);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if(currentEnergyOBM > 0)
            {
                UseEnergyOBM(20);
            }
        }
    }

    //Methods
    void TakeDamageOBM(int a_damageOBM)
    {
        //Health decreases
        currentHealthOBM -= a_damageOBM;
        healthBarSliderOBM.SetHealthOBM(currentHealthOBM);
    }

    void UseEnergyOBM(int a_useEnergyOBM)
    {
        //Energy decreases
        currentEnergyOBM -= a_useEnergyOBM;
        energyBarSliderOBM.SetEnergyOBM(currentEnergyOBM);
    }

    void RechargeEnergyOBM(int a_rechargeEnergyOBM)
    {
        //energy increases
        currentEnergyOBM += a_rechargeEnergyOBM;
        energyBarSliderOBM.SetEnergyOBM(currentEnergyOBM);
    }
}
