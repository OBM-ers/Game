using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : MonoBehaviour
{
    //variables
    public Transform firePointObm;
    public GameObject bulletPrefabObm;
    public float timeToShootObm;
    public float delayToShootObm;
    private float currentTimeObm;
    public bool shootRightObm = false;

    // Start is called before the first frame update
    void Start()
    {
        currentTimeObm = delayToShootObm;

        if (shootRightObm)
        {
            bulletPrefabObm.transform.Rotate(0f, 180f, 0f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        currentTimeObm -= Time.deltaTime;
        //If currentTimeObm is tinier or equal to timeToShootObm then the enemy fires.
        if (currentTimeObm <= timeToShootObm)
        {
            ShootObm();
            Debug.Log("Shoot");
            currentTimeObm = delayToShootObm;
        }
    }

    public void ShootObm()
    {
        //shoots a bullet
        Instantiate(bulletPrefabObm, firePointObm.position, firePointObm.rotation);
    }
}
