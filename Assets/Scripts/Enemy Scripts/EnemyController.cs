using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //Variables
    public bool enablePatrolObm = false;
    private bool enableEnablePatrolObm = false;

    public float enemySpeedObm;
    public float distanceObm;
    public float checkRadiusObm;
    public float healthObm;

    public int damageObm;
    private float elapsedCollisionTimeObm = 1;
    private float necessaryCollisionTimeObm = 1;

    private bool movingRightObm = true;

    public Transform groundCheckObm;
    public ParticleSystem bloodParticlesObm;
    public LayerMask wallCheckObm;
    public Animator animatorObm;
    public AudioSource hitSoundObm;
    private Rigidbody2D enemyRigidbodyObm;
    private GameObject playerObm;

    private void Awake()
    {
        //Takes rigidbody from enemy and puts the player object into the variable playerObm
        enemyRigidbodyObm = GetComponent<Rigidbody2D>();
        playerObm = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        //checks if enemy can patrol
        if (enablePatrolObm == true)
        {
            enableEnablePatrolObm = true;
            EnemyPatrolObm();
        }
        //if enemy is dead, gameobject destroyed
        if (healthObm <= 0)
        {
            Destroy(gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
            Debug.Log("DEATH");
        }
    }

    private void EnemyPatrolObm()
    {
        //patrolling, checks if the enemy can walk forward otherwise he turns around
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
            else if (movingRightObm == false)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRightObm = true;
            }
        }
    }

    public void TakeDamageObm(int a_takeDamageObm)
    { 
        //Enemy takes damage when hit
        healthObm -= a_takeDamageObm;
        var m_mainObm = bloodParticlesObm.main;
        m_mainObm.startDelay = this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length / 2;
        //particles and sound
        bloodParticlesObm.Play();
        hitSoundObm.Play();
        //knockback
        StartCoroutine(KnockbackObm(0.05f, 12f, playerObm.transform.localScale));
    }

    private void OnCollisionStay2D(Collision2D a_collisionObm)
    {
        //On collision, checks if it's a player. If so, damages player
        if (a_collisionObm.gameObject.name == "Player")
        {
            elapsedCollisionTimeObm += Time.fixedDeltaTime;
            if (elapsedCollisionTimeObm > necessaryCollisionTimeObm)
            {
                a_collisionObm.gameObject.GetComponent<PlayerHud>().TakeDamageObm(damageObm);
                elapsedCollisionTimeObm = 0;
            }
            
        }
    }

    //Knockback
    public IEnumerator KnockbackObm(float a_knockDurationObm, float a_KnockbackPowerObm, Vector3 a_knockbackDirectionObm)
    {
        float m_timerObm = 0;
        if (enableEnablePatrolObm)
        {
            enablePatrolObm = false;
        }

        //add force, while knockDuration is bigger than timer. 
        while (a_knockDurationObm > m_timerObm)
        {
            m_timerObm += Time.deltaTime;
            enemyRigidbodyObm.AddForce(new Vector3(a_knockbackDirectionObm.x * 30, a_knockbackDirectionObm.y * a_KnockbackPowerObm, 0f));
        }

        if(enableEnablePatrolObm)
        {
            enablePatrolObm = true;
        }
        
        yield return 0;
    }
}
