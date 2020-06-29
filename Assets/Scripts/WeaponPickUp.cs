using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class WeaponPickUp : MonoBehaviour
{
    //variables
    public GameObject swordObm;
    public GameObject scytheObm;

    public SpriteRenderer spriteRendererObm;
    public Sprite swordSpriteObm;
    public Sprite scytheSpriteObm;

    private float timerObm = 2f;
    private bool weaponSwitchedObm = false;
    private bool cooldownWeaponObm = false;

    void Update()
    {
        //checks if the cooldown of the weaponpickup so you can't spam the weaponpickup function
        if (cooldownWeaponObm == true)
        {
            if(timerObm <= 0)
            {
                cooldownWeaponObm = false;
            }
            else
            {
                timerObm -= Time.deltaTime;
            }
        }
    }

    //Picks up weapon when the colliding with 
    private void OnTriggerEnter2D(Collider2D playerObm)
    {
        if (playerObm.tag == "Player")
        {
            if (cooldownWeaponObm == false)
            {
                if (weaponSwitchedObm == false)
                {
                    swordObm.SetActive(false);
                    scytheObm.SetActive(true);
                    spriteRendererObm.sprite = swordSpriteObm;
                    weaponSwitchedObm = true;
                }
                else
                {
                    swordObm.SetActive(true);
                    scytheObm.SetActive(false);
                    spriteRendererObm.sprite = scytheSpriteObm;
                    weaponSwitchedObm = false;
                }
                cooldownWeaponObm = true;
                timerObm = 2f;
            }
        }
    }
}
