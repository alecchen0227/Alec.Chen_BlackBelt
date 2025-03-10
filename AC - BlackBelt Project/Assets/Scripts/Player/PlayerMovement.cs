using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    private float moveSpeed = 7;

    public float groundDrag;

    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool readyToJump = true;

    [Header("KeyBinds")]
    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode shiftKey = KeyCode.LeftShift;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGrounded;
    bool grounded;
    bool soundReady = true;


    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    AudioSource source;
    public AudioClip[] clip;

    private int stepCounter;

    public Image staminaBar;
    float staminaAmount = 1;

    // Start is called before the first frame update
    void Start()
    {
        source = gameObject.GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        // ground check
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGrounded);

        MyInput();
        SpeedControl();
        ChangeSpeed();

        // halde drag
        if (grounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;
    }

    private void FixedUpdate()
    {
        MovePlayer();
        changeStaminaBar();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        // when to jump
        if (Input.GetKey(jumpKey) && readyToJump && grounded && Pause.pauseCondition)
        {
            readyToJump = false;

            Jump();

            Invoke("ResetJump", jumpCooldown);
        }
    }

    private void ChangeSpeed() //This method is called every update and changes the speed of the player if shift is held and stamina is above 0
    {
        if(Input.GetKey(shiftKey) && staminaAmount > 0)
        {
            moveSpeed = 14;
            if(staminaAmount > 0)
            {
                staminaAmount -= 0.2f*Time.deltaTime;
            }
        }
        else
        {
            moveSpeed = 7;
        }
    }

    private void MovePlayer()
    {
        // calculate movement direction
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        // on ground
        if (grounded)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Acceleration);
        }

        // in air
        else if (!grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Acceleration);
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        // limit velocity if needed
        if (flatVel.magnitude > moveSpeed)
        {
            if (stepCounter < clip.Length && soundReady) // Plays the sound of footsteps every second while the player is moving
            {
                source.clip = clip[stepCounter];
                stepCounter++;
                soundReady = false;
                source.Play();
                Invoke("ResetSound", 1);
            }
            else
            {
                stepCounter = 0;
            }
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    private void changeStaminaBar() // Updates the stamina bar while shift is not held and stamina is less than 1
    {
        staminaBar.fillAmount = staminaAmount;
        if (!Input.GetKey(shiftKey) && staminaAmount < 1)
        {
            staminaAmount += 0.1f*Time.deltaTime;
        }
    }

    private void Jump()
    {
        // reset y velocity
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.VelocityChange);
    }

    private void ResetJump()
    {
        readyToJump = true;
    }

    public void ResetSound()
    {   
        soundReady = true;
    }
}
