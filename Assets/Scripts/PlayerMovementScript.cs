using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : PhysicsScript
{
    public float maxSpeedObm = 7;
    public float jumpTakeoffSpeedObm = 7;

    void Start()
    {
        
    }

    protected override void ComputeVelocityObm()
    {
        Vector2 m_moveObm = Vector2.zero;

        m_moveObm.x = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump") && groundedObm)
        {
            velocityObm.y = jumpTakeoffSpeedObm;
        }
        else if (Input.GetButtonUp("Jump"))
        {
            if (velocityObm.y > 0)
            {
                velocityObm.y = velocityObm.y * .5f;
            }
        }

        targetVelocityObm = m_moveObm * maxSpeedObm;
    }
}