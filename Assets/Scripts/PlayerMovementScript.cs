using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    private Rigidbody2D playerRigidbodyObm;

    // Input variables
    private float xInputObm = 0f;
    // Speed variables
    public float runSpeedObm = 40f;
    public float jumpSpeedObm = 400f;
    public float movementSmoothingObm = .05f;
    // Jump variables
    public float fallMultiplierObm = 250f;
    public float lowJumpMultiplierObm = 200f;
    private bool isGroundedObm = true;

    private Vector3 VelocityObm = Vector3.zero;

    void Awake()
    {
        playerRigidbodyObm = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        xInputObm = Input.GetAxisRaw("Horizontal") * runSpeedObm * Time.fixedDeltaTime;
        MoveObm();
    }

    private void MoveObm()
    {
        Vector3 targetVelocityObm = new Vector2(xInputObm * 10f, playerRigidbodyObm.velocity.y);
        playerRigidbodyObm.velocity = Vector3.SmoothDamp(playerRigidbodyObm.velocity, targetVelocityObm, ref VelocityObm, movementSmoothingObm);

        if (isGroundedObm == true && Input.GetButtonDown("Jump"))
        {
            isGroundedObm = false;
            playerRigidbodyObm.AddForce(new Vector2(0f, jumpSpeedObm));
        }
        //if (playerRigidbodyObm.velocity.y < 0)
        //{
        //    playerRigidbodyObm.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplierObm - 1) * Time.fixedDeltaTime;
        //}
        //else if (playerRigidbodyObm.velocity.y > 0 && !Input.GetButton("Jump"))
        //{
        //    playerRigidbodyObm.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplierObm - 1) * Time.fixedDeltaTime;
        //}

    }

    void OnCollisionEnter2D(Collision2D collisionObm)
    {
        if (collisionObm.gameObject.CompareTag("Ground"))
        {
            isGroundedObm = true;
        }
        Debug.Log("Ground Checked");
    }
}