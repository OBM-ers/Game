using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeleeCombat : MonoBehaviour
{
    public Animator animatorOBM;
    private GameObject getEnergyValueObm;
    private float timerOBM;
    public float timeBetweenAttackOBM;

    public Transform attackPosObm;
    public LayerMask whatIsEnemiesObm;
    public float attackRangeObm = 0.5f;
    public int damageObm = 20;

    // Update is called once per frame
    void Update()
    {
        //Check if cooldown timer is 0 and if the energy bar isn't empty
        if (timerOBM <= 0 && GameObject.Find("Energy bar").GetComponent<Slider>().value > 0 && PauseMenu.gameIsPausedObm == false)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Collider2D[] enemiesToDamageObm = Physics2D.OverlapCircleAll(attackPosObm.position, attackRangeObm, whatIsEnemiesObm);
                for (int i = 0; i < enemiesToDamageObm.Length; i++)
                {
                    enemiesToDamageObm[i].GetComponent<EnemyController>().TakeDamageObm(damageObm);
                    Debug.Log("HIT");
                   
                }
                AttackAnimOBM();
                timerOBM = timeBetweenAttackOBM;
                FindObjectOfType<PlayerHudOBM>().UseEnergyOBM(20);
            }
        }
        timerOBM -= Time.deltaTime;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPosObm.position, attackRangeObm);
    }

    private void AttackAnimOBM()
    {
        animatorOBM.SetTrigger("attack");
    }
}
