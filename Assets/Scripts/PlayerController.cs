using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController2D controller;
    float horizontalInput;
    public float runSpeed;
    public Animator animator;
    bool jumpKey=false;
    bool crouchKey = false;

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalInput));

        if (Input.GetButtonDown("Jump"))
        {
            jumpKey = true;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            crouchKey = true;
        }
        else if (Input.GetKeyUp(KeyCode.S)){
            crouchKey = false;
        }
        
    }
    private void FixedUpdate()
    {
        controller.Move(horizontalInput *Time.fixedDeltaTime,crouchKey,jumpKey);
        jumpKey = false;
    }
}
