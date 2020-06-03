using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerHudOBM : MonoBehaviour
{
    public int maxValuesObm = 100;
    public int currentHealthObm;
    public int currentEnergyObm;

    private float rechargeTimeObm = 2;
    public float timerObm;

    public HealthBarSliderOBM healthBarSliderObm;
    public EnergyBarSliderOBM energyBarSliderObm;

    // Start is called before the first frame update
    void Start()
    {
        currentHealthObm = maxValuesObm;
        healthBarSliderObm.SetMaxHealthObm(maxValuesObm);

        currentEnergyObm = maxValuesObm;
        energyBarSliderObm.SetMaxEnergyObm(maxValuesObm);

        timerObm = rechargeTimeObm;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentEnergyObm != 100)
        {
            timerObm -= Time.deltaTime;

            if(timerObm < 0)
            {
                RechargeEnergyObm(20);
                timerObm = rechargeTimeObm;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamageObm(20);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if(currentEnergyObm > 0)
            {
                UseEnergyObm(20);
            }
        }
    }

    //Methods
    void TakeDamageObm(int a_damageObm)
    {
        currentHealthObm -= a_damageObm;
        healthBarSliderObm.SetHealthObm(currentHealthObm);
    }

    void UseEnergyObm(int a_useEnergyObm)
    {
        currentEnergyObm -= a_useEnergyObm;
        energyBarSliderObm.SetEnergyObm(currentEnergyObm);
    }

    void RechargeEnergyObm(int a_rechargeEnergyObm)
    {
        currentEnergyObm += a_rechargeEnergyObm;
        energyBarSliderObm.SetEnergyObm(currentEnergyObm);
    }
}
