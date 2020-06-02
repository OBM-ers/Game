using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsScript : MonoBehaviour
{
    public float minGroundNormalYObm = .65f;
    public float gravityModifierObm = 1f;

    protected Vector2 targetVelocityObm;
    protected bool groundedObm;
    protected Vector2 groundNormalObm;
    protected Rigidbody2D rigidbody2dObm;
    protected Vector2 velocityObm; // protected variable to be able to use in other classes
    protected ContactFilter2D contactFilterObm;
    protected RaycastHit2D[] hitBufferObm = new RaycastHit2D[16];
    protected List<RaycastHit2D> hitBufferListObm = new List<RaycastHit2D>(16);

    protected const float minMovedistanceObm = 0.001f;
    protected const float shellRadiusObm = 0.01f;

    private void OnEnable()
    {
        rigidbody2dObm = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        contactFilterObm.useTriggers = false;
        contactFilterObm.SetLayerMask(Physics2D.GetLayerCollisionMask(gameObject.layer));
        contactFilterObm.useLayerMask = true;
    }

    void Update()
    {
        targetVelocityObm = Vector2.zero;
        ComputeVelocityObm();
    }

    protected virtual void ComputeVelocityObm() { }

    private void FixedUpdate()
    {
        velocityObm += gravityModifierObm * Physics2D.gravity * Time.deltaTime;
        velocityObm.x = targetVelocityObm.x;

        groundedObm = false;

        Vector2 m_deltaPositionObm = velocityObm * Time.deltaTime;

        Vector2 m_moveAlongGround = new Vector2(groundNormalObm.y, -groundNormalObm.x);

        Vector2 m_moveObm = m_moveAlongGround * m_deltaPositionObm.x;

        MovementObm(m_moveObm, false);

        m_moveObm = Vector2.up * m_deltaPositionObm.y;

        MovementObm(m_moveObm, true);
    }

    void MovementObm(Vector2 a_moveObm, bool a_yMovement)
    {
        float m_distanceObm = a_moveObm.magnitude;

        if (m_distanceObm > minMovedistanceObm)
        {
           int m_count = rigidbody2dObm.Cast(a_moveObm, contactFilterObm, hitBufferObm, m_distanceObm + shellRadiusObm);
            hitBufferListObm.Clear();
            for (int i = 0; i < m_count; i++)
            {
                hitBufferListObm.Add(hitBufferObm[i]);
            }

            for (int i = 0; i < hitBufferListObm.Count; i++)
            {
                Vector2 m_currentNormalObm = hitBufferListObm[i].normal;
                if (m_currentNormalObm.y > minGroundNormalYObm)
                {
                    groundedObm = true;
                    if (a_yMovement)
                    {
                        groundNormalObm = m_currentNormalObm;
                        m_currentNormalObm.x = 0;
                    }
                }
                float m_projection = Vector2.Dot(velocityObm, m_currentNormalObm);
                if (m_projection < 0)
                {
                    velocityObm = velocityObm - m_projection * m_currentNormalObm;
                }

                float m_modifiedDistance = hitBufferListObm[i].distance - shellRadiusObm;
                m_distanceObm = m_modifiedDistance < m_distanceObm ? m_modifiedDistance : m_distanceObm;
            }
        }
        rigidbody2dObm.position = rigidbody2dObm.position + a_moveObm.normalized * m_distanceObm;
    }
}