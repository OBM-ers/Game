using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float bulletSpeedObm;
    public int bulletDamageObm;
    public Rigidbody2D rigidbodyBulletObm;
    private bool fireRightObm;
    public GameObject shootingEnemy;

    void Start()
    {
        fireRightObm = shootingEnemy.GetComponent<EnemyFire>().shootRight;
        if (fireRightObm)
        {
            rigidbodyBulletObm.velocity = transform.right * bulletSpeedObm;
        } else if (!fireRightObm)
        {
            rigidbodyBulletObm.velocity = -transform.right * bulletSpeedObm;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collisionObm)
    {
        if (collisionObm.CompareTag("Player"))
        {
            Destroy(gameObject);
            collisionObm.gameObject.GetComponent<PlayerHudOBM>().TakeDamageOBM(bulletDamageObm);
        }
        else if (collisionObm.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
}
