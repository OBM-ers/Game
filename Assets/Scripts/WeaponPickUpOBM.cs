using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class WeaponPickUpOBM : MonoBehaviour
{
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
