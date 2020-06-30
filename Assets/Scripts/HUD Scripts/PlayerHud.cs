using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHud : MonoBehaviour
{
    //Variables
    public GameObject gameOverScreenObm;

    public int maxValuesObm = 100;
    private int currentHealthObm;
    private int currentEnergyObm;

    private float rechargeTimeObm = 2;
    private float timerObm;

    public HealthBarSlider healthBarSliderObm;
    public EnergyBarSlider energyBarSliderObm;
    public Transform spawnPointObm;
    public AudioSource deathSoundObm;

    // Start is called before the first frame update
    void Start()
    {
        //timescale is how fast time goes. 1f is normal pace.
        Time.timeScale = 1f;
        gameOverScreenObm.SetActive(false);

        //Set health and energy
        currentHealthObm = maxValuesObm;
        healthBarSliderObm.SetMaxHealthObm(maxValuesObm);

        currentEnergyObm = maxValuesObm;
        energyBarSliderObm.SetMaxEnergyObm(maxValuesObm);

        timerObm = rechargeTimeObm;
    }

    // Update is called once per frame
    void Update()
    {
        //Recharge energy
        if(currentEnergyObm != 100)
        {
            timerObm -= Time.deltaTime;

            if(timerObm < 0)
            {
                RechargeEnergyObm(20);
                //reset recharge time to 2 seconds
                timerObm = rechargeTimeObm;
            }
        }

        if(currentHealthObm <= 0)
        {
            gameObject.transform.position = spawnPointObm.position;
            currentHealthObm = maxValuesObm;
            deathSoundObm.Play();
        }
    }

    //Methods
    public void TakeDamageObm(int a_damageObm)
    {
        //Health decreases
        currentHealthObm -= a_damageObm;
        healthBarSliderObm.SetHealthObm(currentHealthObm);
        Debug.Log("Health: " + currentHealthObm);

        if (currentHealthObm <= 0)
        {
            gameOverScreenObm.SetActive(true);
            Time.timeScale = 0.0001f;
        }
    }

    public void UseEnergyObm(int a_useEnergyObm)
    {
        //Energy decreases
        currentEnergyObm -= a_useEnergyObm;
        energyBarSliderObm.SetEnergyObm(currentEnergyObm);
    }

    public void RechargeEnergyObm(int a_rechargeEnergyObm)
    {
        //Energy increases
        currentEnergyObm += a_rechargeEnergyObm;
        energyBarSliderObm.SetEnergyObm(currentEnergyObm);
    }
}
