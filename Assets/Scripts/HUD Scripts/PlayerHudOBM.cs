using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHudOBM : MonoBehaviour
{
    public GameObject gameOverScreenObm;

    public int maxValuesOBM = 100;
    private int currentHealthOBM;
    private int currentEnergyOBM;

    private float rechargeTimeOBM = 2;
    private float timerOBM;

    public HealthBarSliderOBM healthBarSliderOBM;
    public EnergyBarSliderOBM energyBarSliderOBM;
    public Transform spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        gameOverScreenObm.SetActive(false);

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

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if(currentEnergyOBM > 0)
            {
                UseEnergyOBM(20);
            }
        }
    }

    //Methods
    public void TakeDamageOBM(int a_damageOBM)
    {
        //Health decreases
        currentHealthOBM -= a_damageOBM;
        healthBarSliderOBM.SetHealthOBM(currentHealthOBM);
        Debug.Log("Health: " + currentHealthOBM);

        if (currentHealthOBM <= 0)
        {
            Debug.Log("dead");
            gameOverScreenObm.SetActive(true);
            Time.timeScale = 0.0001f;
        }
    }

    public void UseEnergyOBM(int a_useEnergyOBM)
    {
        //Energy decreases
        currentEnergyOBM -= a_useEnergyOBM;
        energyBarSliderOBM.SetEnergyOBM(currentEnergyOBM);
    }

    public void RechargeEnergyOBM(int a_rechargeEnergyOBM)
    {
        //energy increases
        currentEnergyOBM += a_rechargeEnergyOBM;
        energyBarSliderOBM.SetEnergyOBM(currentEnergyOBM);
    }
}
