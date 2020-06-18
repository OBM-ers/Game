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

    public int damageObm;

    private bool movingRightObm = true;

    public Transform groundCheckObm;
    public ParticleSystem bloodParticlesObm;
    public LayerMask wallCheckObm;
    public Animator animatorOBM;
    private Rigidbody2D enemyRigidbodyObm;
    private GameObject playerObm;

    private void Awake()
    {
        enemyRigidbodyObm = GetComponent<Rigidbody2D>();
        playerObm = GameObject.FindWithTag("Player");
    }

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
        var m_mainObm = bloodParticlesObm.main;
        m_mainObm.startDelay = this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length / 2;
        bloodParticlesObm.Play();

        StartCoroutine(KnockbackObm(0.05f, 15f, playerObm.transform.localScale));
    }

    private void OnCollisionEnter2D(Collision2D a_collisionObm)
    {
        if (a_collisionObm.gameObject.name == "Player")
        {
            a_collisionObm.gameObject.GetComponent<PlayerHudOBM>().TakeDamageOBM(damageObm);
        }
    }

    public IEnumerator KnockbackObm(float a_knockDurationObm, float a_KnockbackPowerObm, Vector3 a_knockbackDirectionObm)
    {
        float m_timerObm = 0;
        enablePatrolObm = false;

        while (a_knockDurationObm > m_timerObm)
        {
            m_timerObm += Time.deltaTime;
            enemyRigidbodyObm.AddForce(new Vector3(a_knockbackDirectionObm.x * 23, a_knockbackDirectionObm.y * a_KnockbackPowerObm, 0f));
        }

        enablePatrolObm = true;

        yield return 0;
    }
}
