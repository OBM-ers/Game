using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsScript : MonoBehaviour
{
    public float minGroundNormalY = .65f;
    public float gravityModifierObm = 1f;

    protected bool grounded;
    protected Vector2 groundNormal;
    protected Rigidbody2D rigidbody2dObm;
    protected Vector2 velocityObm; // protected variable to be able to use in other classes
    protected ContactFilter2D contactFilter;
    protected RaycastHit2D[] hitBuffer = new RaycastHit2D[16];
    protected List<RaycastHit2D> hitBufferList = new List<RaycastHit2D>(16);

    protected const float minMovedistanceObm = 0.001f;
    protected const float shellRadiusObm = 0.01f;

    private void OnEnable()
    {
        rigidbody2dObm = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        contactFilter.useTriggers = false;
        contactFilter.SetLayerMask(Physics2D.GetLayerCollisionMask(gameObject.layer));
        contactFilter.useLayerMask = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        velocityObm += gravityModifierObm * Physics2D.gravity * Time.deltaTime;

        grounded = false;

        Vector2 deltaPositionObm = velocityObm * Time.deltaTime;

        Vector2 moveObm = Vector2.up * deltaPositionObm.y;

        MovementObm(moveObm, true);
    }

    void MovementObm(Vector2 a_moveObm, bool a_yMovement)
    {
        float m_distanceObm = a_moveObm.magnitude;

        if (m_distanceObm > minMovedistanceObm)
        {
           int m_count = rigidbody2dObm.Cast(a_moveObm, contactFilter, hitBuffer, m_distanceObm + shellRadiusObm);
            hitBufferList.Clear();
            for (int i = 0; i < count; i++)
            {
                hitBufferList.Add(hitBuffer[i]);
            }

            for (int i = 0; i < hitBufferList.Count; i++)
            {
                Vector2 currentNormal = hitBufferList[i].normal;
                if (currentNormal.y > minGroundNormalY)
                {
                    grounded = true;
                    if (a_yMovement)
                    {
                        groundNormal = currentNormal;
                        currentNormal.x = 0;
                    }
                }
                float m_projection = Vector2.Dot(velocityObm, currentNormal);
                if (m_projection < 0)
                {
                    velocityObm = velocityObm - m_projection * currentNormal;
                }

                float m_modifiedDistance = hitBufferList[i].distance - shellRadiusObm;
                m_distanceObm = m_modifiedDistance < m_distanceObm ? m_modifiedDistance : m_distanceObm;
            }

        }

        rigidbody2dObm.position = rigidbody2dObm.position + a_moveObm.normalized * m_distanceObm;
    }
}
