﻿using System.Collections;
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
                timerOBM = rechargeTimeOBM;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
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
        currentHealthOBM -= a_damageOBM;
        healthBarSliderOBM.SetHealthOBM(currentHealthOBM);
    }

    void UseEnergyOBM(int a_useEnergyOBM)
    {
        currentEnergyOBM -= a_useEnergyOBM;
        energyBarSliderOBM.SetEnergyOBM(currentEnergyOBM);
    }

    void RechargeEnergyOBM(int a_rechargeEnergyOBM)
    {
        currentEnergyOBM += a_rechargeEnergyOBM;
        energyBarSliderOBM.SetEnergyOBM(currentEnergyOBM);
    }
}