using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using UnityEngine;
using UnityEngine.EventSystems;



public class PlayerMovementScript : MonoBehaviour
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

        ControllerDriverObm controllerScriptObm = playerObm.GetComponent<ControllerDriverObm>();
        
        // MOVE        
       
        if (controllerScriptObm.controllerEnabledObm==false)
        {
            xInputObm = Input.GetAxisRaw("Horizontal") * runSpeedObm * Time.fixedDeltaTime;
        }
        else
        {
            
            if (controllerScriptObm.controllerInputObm == "1" || controllerScriptObm.controllerInputObm == "-1")
            {
                //xInputObm = GetFLoatObm(controllerScriptObm.controllerInputObm, 0.0f) * runSpeedObm * Time.fixedDeltaTime;
                int TestObm = Convert.ToInt32(controllerScriptObm.controllerInputObm);
                float Test2Obm = (float)TestObm;
                Debug.Log(Test2Obm);
                xInputObm = Test2Obm * runSpeedObm * Time.fixedDeltaTime;
            }
            else
            {
                xInputObm = 0f;
            }
        }
                 
        Vector3 targetVelocityObm = new Vector2(xInputObm * 10f, playerRigidbodyObm.velocity.y);
        playerRigidbodyObm.velocity = Vector3.SmoothDamp(playerRigidbodyObm.velocity, targetVelocityObm, ref VelocityObm, movementSmoothingObm);
        
       if(controllerScriptObm.controllerEnabledObm == true)
        {
            isGroundedObm = Physics2D.OverlapCircle(groundCheckObm.position, checkRadiusObm, whatIsGroundObm);
            if (playerRigidbodyObm.velocity.y < 0)
            {
                playerRigidbodyObm.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplierObm - 1) * Time.fixedDeltaTime;
            }
            else if (playerRigidbodyObm.velocity.y > 0 && controllerScriptObm.controllerInputObm != "5")
            {
                playerRigidbodyObm.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplierObm - 1) * Time.fixedDeltaTime;
            }
        }
        else {
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
            // JUMP CALCULATION
            
        
        
        
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
        Debug.Log(resultObm);
        return resultObm;
    }

    private void JumpObm()
    {
        ControllerDriverObm controllerScriptObm = playerObm.GetComponent<ControllerDriverObm>();
        if (controllerScriptObm.controllerEnabledObm == true)
        {                  
            if (isGroundedObm == true && controllerScriptObm.controllerInputObm == "5")
            {
                isGroundedObm = false;
                playerRigidbodyObm.AddForce(new Vector2(0f, jumpSpeedObm));
                Debug.Log(jumpSpeedObm);
                jumpSoundObm.Play();
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
        facingrightObm = !facingrightObm;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
}
