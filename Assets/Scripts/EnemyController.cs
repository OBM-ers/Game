using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public bool enablePatrolObm = false;

    public float enemySpeedObm;
    public float distanceObm;
    public float checkRadiusObm;
    public float startDazedTimeObm;
    public float healthObm;

    public int damageObm;

    private bool movingRightObm = true;
    private float dazedTimeObm;

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
        if(dazedTimeObm <= 0)
        {
            enemySpeedObm = 1;
        } else
        {
            enemySpeedObm = 0;
            dazedTimeObm -= Time.deltaTime;
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
        //dazedTimeObm = startDazedTimeObm;
        healthObm -= a_takeDamageObm;
        var main = bloodParticlesObm.main;
        main.startDelay = this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length / 2;
        bloodParticlesObm.Play();

        if(this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length < 0)
        {
            StartCoroutine(KnockbackObm(0.05f, 2f, playerObm.transform.localScale));
        } 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            collision.gameObject.GetComponent<PlayerHudOBM>().TakeDamageOBM(damageObm);
        }
    }

    public IEnumerator KnockbackObm(float knockDurationObm, float KnockbackPowerObm, Vector3 knockbackDirectionObm)
    {
        Debug.Log("ja");
        Vector3 forceObm;
        float timerObm = 0;
        while ( knockDurationObm > timerObm)
        {
            forceObm = new Vector3(knockbackDirectionObm.x * -100, knockbackDirectionObm.y * KnockbackPowerObm, 0f);
            
            timerObm += Time.deltaTime;

            enablePatrolObm = false;
            enemyRigidbodyObm.AddForce(forceObm);
        }

        enablePatrolObm = true;

        yield return 0;
    }
}
