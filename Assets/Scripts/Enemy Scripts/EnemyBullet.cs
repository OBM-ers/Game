using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    //Variables
    public float bulletSpeedObm;
    public int bulletDamageObm;
    public Rigidbody2D rigidbodyBulletObm;
    private bool fireRightObm;
    public GameObject shootingEnemyObm;

    void Start()
    {
        //Checks if the enemy needs to fire left or right
        fireRightObm = shootingEnemyObm.GetComponent<EnemyFire>().shootRightObm;
        if (fireRightObm)
        {
            rigidbodyBulletObm.velocity = transform.right * bulletSpeedObm;
        } 
        else if (!fireRightObm)
        {
            rigidbodyBulletObm.velocity = -transform.right * bulletSpeedObm;
        }
    }

    private void OnTriggerEnter2D(Collider2D collisionObm)
    {
        //On collions with player --> Damage to player. Otherwise gameobject destroyed
        if (collisionObm.CompareTag("Player"))
        {
            Destroy(gameObject);
            collisionObm.gameObject.GetComponent<PlayerHud>().TakeDamageObm(bulletDamageObm);
        }
        else if (collisionObm.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
}
