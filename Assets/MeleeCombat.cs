using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeCombat : MonoBehaviour
{
    public Animator animatorOBM;
    private float timerOBM;
    public float timeBetweenAttackOBM;


    // Update is called once per frame
    void Update()
    {
        timerOBM -= Time.deltaTime;

        if(timerOBM <= 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                AttackOBM();
                timerOBM = timeBetweenAttackOBM;
            }
            
        }

        
    }

    private void AttackOBM()
    {
        animatorOBM.SetTrigger("attack");
    }
}
