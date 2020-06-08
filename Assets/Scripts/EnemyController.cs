using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float enemySpeedObm;
    public float distanceObm;
    public float checkRadiusObm;

    private bool movingRightObm = true;

    public Transform groundCheckObm;
    public LayerMask wallCheckObm;

    void Update()
    {
        moveEnemyObm();
    }

    private void moveEnemyObm()
    {
        transform.Translate(Vector2.right * enemySpeedObm * Time.deltaTime);

        RaycastHit2D groundInfoObm = Physics2D.Raycast(groundCheckObm.position, Vector2.down, distanceObm);

        bool m_isWallObm = Physics2D.OverlapCircle(groundCheckObm.position, checkRadiusObm, wallCheckObm);

        if (groundInfoObm.collider == false || m_isWallObm == true)
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
}
