using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeleeCombat : MonoBehaviour
{
    //Variables
    public Animator animatorObm;
    private GameObject getEnergyValueObm;
    private float timerObm;
    public float timeBetweenAttackObm;

    public Transform attackPosObm;
    public LayerMask whatIsEnemiesObm;
    public float attackRangeObm = 0.5f;
    public int damageObm = 20;
    private GameObject playerObm;

    void Start()
    {
        playerObm = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        ControllerDriver controllerScriptObm = playerObm.GetComponent<ControllerDriver>();
        if (controllerScriptObm.controllerEnabledObm == true)
        {
            controllerAttackObm();
        }
        else
        {
            //Check if cooldown timer is 0 and if the energy bar isn't empty also if the pausemenu is false
            if (timerObm <= 0 && GameObject.Find("Energy bar").GetComponent<Slider>().value > 0)
            {
                //Fire1 is the input to attack (Leftmouse button)
                if (Input.GetButtonDown("Fire1"))
                {
                    //Checks how many enemies were hit
                    Collider2D[] enemiesToDamageObm = Physics2D.OverlapCircleAll(attackPosObm.position, attackRangeObm, whatIsEnemiesObm);
                    for (int i = 0; i < enemiesToDamageObm.Length; i++)
                    {
                        //Enemy takes damage
                        enemiesToDamageObm[i].GetComponent<EnemyController>().TakeDamageObm(damageObm);
                        Debug.Log("HIT");
                    }
                    AttackAnimObm();
                    timerObm = timeBetweenAttackObm;
                    FindObjectOfType<PlayerHud>().UseEnergyObm(20);
                }
            }
            timerObm -= Time.deltaTime;
        }
        
    }

    //Same as the function before but checks for controller input
    public void controllerAttackObm()
    {
        ControllerDriver controllerScriptObm = playerObm.GetComponent<ControllerDriver>();

        if (controllerScriptObm.attackInputObm == true)
        {
            if (timerObm <= 0 && GameObject.Find("Energy bar").GetComponent<Slider>().value > 0)
            {
                Collider2D[] enemiesToDamageObm = Physics2D.OverlapCircleAll(attackPosObm.position, attackRangeObm, whatIsEnemiesObm);
                for (int i = 0; i < enemiesToDamageObm.Length; i++)
                {
                    enemiesToDamageObm[i].GetComponent<EnemyController>().TakeDamageObm(damageObm);
                    Debug.Log("HIT");
                }
                AttackAnimObm();
                timerObm = timeBetweenAttackObm;
                FindObjectOfType<PlayerHud>().UseEnergyObm(20);
                controllerScriptObm.attackInputObm = false;
            }
            timerObm -= Time.deltaTime;
        }        
    }
    private void OnDrawGizmosSelected()
    {
        //gizmos is to see the range of the weapon. Good for debugging
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPosObm.position, attackRangeObm);
    }

    private void AttackAnimObm()
    {
        //attack animation
        animatorObm.SetTrigger("attack");
    }
}
