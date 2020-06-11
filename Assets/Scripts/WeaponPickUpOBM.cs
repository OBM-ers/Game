using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickUpOBM : MonoBehaviour
{
    //public WeaponOBM weaponObm;

    public GameObject swordObm;
    public GameObject scytheObm;

    private void OnTriggerEnter2D(Collider2D playerObm)
    {
        if(playerObm.tag == "Player")
        {
            swordObm.SetActive(false);
            scytheObm.SetActive(true);
            Destroy(gameObject);
        }
    }
}
