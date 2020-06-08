using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float enemySpeedObm;
    public float distanceObm;

    private bool movingRightObm = true;

    public Transform groundCheckObm;

    void Update()
    {
        transform.Translate(Vector2.right * enemySpeedObm * Time.deltaTime);

        RaycastHit2D groundInfoObm = Physics2D.Raycast(groundCheckObm.position, Vector2.down, distanceObm);
        if (groundInfoObm.collider == false) {
            if (movingRightObm == true) {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRightObm = false;
            } else {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRightObm = true;
            }
        }
    }
}
