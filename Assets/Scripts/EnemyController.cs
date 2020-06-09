using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public bool enablePatrolObm = false;

    public float enemySpeedObm;
    public float distanceObm;
    public float checkRadiusObm;

    public float healthObm;

    private bool movingRightObm = true;

    public Transform groundCheckObm;
    public ParticleSystem bloodParticlesObm;
    public LayerMask wallCheckObm;
    public Animator animatorOBM;

    void Update()
    {
        if (enablePatrolObm == true)
        {
            enemyPatrolObm();
        }
        if (healthObm <= 0)
        {
            Destroy(gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
            Debug.Log("DEATH");
        }
    }

    private void enemyPatrolObm()
    {
        transform.Translate(Vector2.right * enemySpeedObm * Time.deltaTime);

        RaycastHit2D m_groundInfoObm = Physics2D.Raycast(groundCheckObm.position, Vector2.down, distanceObm);

        bool m_isWallObm = Physics2D.OverlapCircle(groundCheckObm.position, checkRadiusObm, wallCheckObm);

        if (m_groundInfoObm.collider == false || m_isWallObm == true)
        {
            if (movingRightObm == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRightObm = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRightObm = true;
            }
        }
    }

    public void TakeDamageObm(int a_takeDamageObm)
    {
        healthObm -= a_takeDamageObm;
        var main = bloodParticlesObm.main;
        main.startDelay = this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length / 2;
        bloodParticlesObm.Play();
        Debug.Log("pp");
    
    }
}
