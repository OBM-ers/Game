using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D playerRigidbodyObm;
    public Animator animatorObm;
    public AudioSource jumpSoundObm;
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
    private GameObject playerObm;

    void Start()
    {
        playerObm = GameObject.FindWithTag("Player");
    }

    void Awake()
    {
        playerRigidbodyObm = GetComponent<Rigidbody2D>();     
        Time.timeScale = 1f;
    }

    void Update()
    {
        JumpObm();
        // ANIMATION
        animatorObm.SetFloat("Speed", Mathf.Abs(xInputObm));
    }

    void FixedUpdate()
    {
        MoveObm();   
    }

    private void MoveObm()
    {
        //Checks for controller
        ControllerDriver controllerScriptObm = playerObm.GetComponent<ControllerDriver>();
        
        // MOVE        
        if (controllerScriptObm.controllerEnabledObm==false)
        {
            //Calculates the input given to walk
            xInputObm = Input.GetAxisRaw("Horizontal") * runSpeedObm * Time.fixedDeltaTime;
        }
        else
        {
            if (controllerScriptObm.controllerInputObm == "1" || controllerScriptObm.controllerInputObm == "-1")
            {
                int inputIntegerObm = Convert.ToInt32(controllerScriptObm.controllerInputObm);
                float inputFloatObm = (float)inputIntegerObm;
                xInputObm = inputFloatObm * runSpeedObm * Time.fixedDeltaTime;
            }
            else
            {
                xInputObm = 0f;
            }
        }
        
        //this is for the basic inputs with WASD
        Vector3 targetVelocityObm = new Vector2(xInputObm * 10f, playerRigidbodyObm.velocity.y);
        playerRigidbodyObm.velocity = Vector3.SmoothDamp(playerRigidbodyObm.velocity, targetVelocityObm, ref VelocityObm, movementSmoothingObm);

        // JUMP CALCULATION
        if (controllerScriptObm.controllerEnabledObm == true)
        {
            //checks if object hit the ground.
            isGroundedObm = Physics2D.OverlapCircle(groundCheckObm.position, checkRadiusObm, whatIsGroundObm);
            //checks if the jump button is pressed and if not, the object needs to fall down quicker.
            if (playerRigidbodyObm.velocity.y < 0)
            {
                playerRigidbodyObm.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplierObm - 1) * Time.fixedDeltaTime;
            }
            else if (playerRigidbodyObm.velocity.y > 0 && controllerScriptObm.jumpInputObm == false)
            {
                playerRigidbodyObm.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplierObm - 1) * Time.fixedDeltaTime;
            }
        }
        //Mouse & Keyboard
        else 
        {
            isGroundedObm = Physics2D.OverlapCircle(groundCheckObm.position, checkRadiusObm, whatIsGroundObm);
            if (playerRigidbodyObm.velocity.y < 0)
            {
                playerRigidbodyObm.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplierObm - 1) * Time.fixedDeltaTime;
            }
            else if (playerRigidbodyObm.velocity.y > 0 && !Input.GetButton("Jump"))
            {
                playerRigidbodyObm.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplierObm - 1) * Time.fixedDeltaTime;
            }
        }

        // FLIP Character left or right
        if (xInputObm < 0f && facingrightObm == true)
        {
            flipObm();
        }
        else if (xInputObm > 0f && facingrightObm == false)
        {
            flipObm();
        }
    }

    private void JumpObm()
    {
        ControllerDriver controllerScriptObm = playerObm.GetComponent<ControllerDriver>();
        if (controllerScriptObm.controllerEnabledObm == true)
        {                  
            if (isGroundedObm == true && controllerScriptObm.jumpInputObm == true)
            {
                //Player jumps. Gains extra height with Addforce
                isGroundedObm = false;
                playerRigidbodyObm.AddForce(new Vector2(0f, jumpSpeedObm));
                jumpSoundObm.Play();
                controllerScriptObm.jumpInputObm = false;
            }
            else if(isGroundedObm == false)
            {
                playerRigidbodyObm.AddForce(new Vector2(0f, 0));
            }
        }
        else
        {
            if (isGroundedObm == true && Input.GetButtonDown("Jump"))
            {
                isGroundedObm = false;
                playerRigidbodyObm.AddForce(new Vector2(0f, jumpSpeedObm));
                jumpSoundObm.Play();
            }
        }
    }

    private void flipObm()
    {
        //flips the character
        facingrightObm = !facingrightObm;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
}
