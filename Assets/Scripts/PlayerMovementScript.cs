using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using UnityEngine;
using UnityEngine.EventSystems;



public class PlayerMovementScript : MonoBehaviour
{
    SerialPort ControllerDataObm;
    private Rigidbody2D playerRigidbodyObm;
    // Input variables
    private float xInputObm = 0f;
    // Speed variables
    public float runSpeedObm = 40f;
    public float jumpSpeedObm = 400f;
    private Vector3 VelocityObm = Vector3.zero;
    public float movementSmoothingObm = .05f;
    public float fallMultiplierObm = 2.5f;
    public float lowJumpMultiplierObm = 2f;
    // Ground check variables
    private bool isGroundedObm;
    public Transform groundCheckObm;
    public float checkRadiusObm;
    public LayerMask whatIsGroundObm;
    // Flip character variable
    private bool facingrightObm = true;
    //Controller variables
    public bool controllerEnabledObm = false;

    void Awake()
    {
        //string comPortObm = "COM3";
        try { 
            ControllerDataObm = new SerialPort("COM3", 9600);
            ControllerDataObm.ReadTimeout = 10;//10 is the sweetspot
            ControllerDataObm.Open();
            if (ControllerDataObm.IsOpen)
            {
                controllerEnabledObm = true;
            }     
        }
        catch
        {           
        }

        playerRigidbodyObm = GetComponent<Rigidbody2D>();
     
    }

    void Update()
    {
        JumpObm();
    }

    void FixedUpdate()
    {
        MoveObm();
    }

    private void MoveObm()
    {

        // MOVE
        if (controllerEnabledObm)
        {
            if (ControllerDataObm.ReadLine() == "1" || ControllerDataObm.ReadLine() == "-1")
            {
                xInputObm = GetFLoatObm(ControllerDataObm.ReadLine(), 0.0f) * runSpeedObm * Time.fixedDeltaTime;
                Debug.Log("Input: " + xInputObm);
            }

            Debug.Log("Nothing");
        }
        else
        {
            xInputObm = Input.GetAxisRaw("Horizontal") * runSpeedObm * Time.fixedDeltaTime;
            Debug.Log(xInputObm);
        }

        Vector3 targetVelocityObm = new Vector2(xInputObm * 10f, playerRigidbodyObm.velocity.y);
        playerRigidbodyObm.velocity = Vector3.SmoothDamp(playerRigidbodyObm.velocity, targetVelocityObm, ref VelocityObm, movementSmoothingObm);
        // ANIMATION

        // JUMP
        isGroundedObm = Physics2D.OverlapCircle(groundCheckObm.position, checkRadiusObm, whatIsGroundObm);
        if (playerRigidbodyObm.velocity.y < 0)
        {
            playerRigidbodyObm.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplierObm - 1) * Time.fixedDeltaTime;
        }
        else if (playerRigidbodyObm.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            playerRigidbodyObm.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplierObm - 1) * Time.fixedDeltaTime;
        }
        // FLIP
        if (xInputObm < 0f && facingrightObm == true)
        {
            flipObm();
        }
        else if (xInputObm > 0f && facingrightObm == false)
        {
            flipObm();
        }

    }

    private float GetFLoatObm(string stringValueObm, float defaultValueObm)
    {
        float resultObm = defaultValueObm;
        float.TryParse(stringValueObm, out resultObm);

        return resultObm;
    }

    private void JumpObm()
    {
        if (controllerEnabledObm)
        {
            if (isGroundedObm == true && ControllerDataObm.ReadLine() == "5")
            {
                
                //Controller Jump
                isGroundedObm = false;
                playerRigidbodyObm.AddForce(new Vector2(0f, jumpSpeedObm));
                Debug.Log(jumpSpeedObm);
            }
        }
        else
        {
            if (isGroundedObm == true && Input.GetButtonDown("Jump"))
            {
                isGroundedObm = false;
                playerRigidbodyObm.AddForce(new Vector2(0f, jumpSpeedObm));
            }
        }

    }

    private void flipObm()
    {
        facingrightObm = !facingrightObm;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
}