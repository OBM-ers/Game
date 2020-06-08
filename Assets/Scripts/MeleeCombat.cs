using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeCombat : MonoBehaviour
{
    public Animator animatorOBM;
    private float timerOBM;
    public float timeBetweenAttackOBM;

    public Transform attackPosObm;
    public LayerMask whatIsEnemiesObm;
    public float attackRangeObm = 0.5f;
    public int damageObm = 20;


    // Update is called once per frame
    void Update()
    {
        if(timerOBM <= 0)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Collider2D[] enemiesToDamageObm = Physics2D.OverlapCircleAll(attackPosObm.position, attackRangeObm, whatIsEnemiesObm);
                for (int i = 0; i < enemiesToDamageObm.Length; i++)
                {
                    enemiesToDamageObm[i].GetComponent<EnemyController>().TakeDamageObm(damageObm);
                }
                AttackAnimOBM();
                timerOBM = timeBetweenAttackOBM;
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
