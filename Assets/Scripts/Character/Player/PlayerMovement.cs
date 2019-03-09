using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;

    float horizontalMove = 0f;
    public float runSpeed = 40f;
    bool jump = false;

    /// <summary>
    /// Start this instance.  Start is called before the first frame update.
    /// </summary>
    void Start()
    {

    }

    /// <summary>
    /// Update this instance.  Update is called once per frame.
    /// </summary>
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if(Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
    }

    /// <summary>
    /// Fixeds the update.
    /// </summary>
    void FixedUpdate()
    {
        //fixedDeltaTime assures same speed no matter how frequent this function is called
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);// crouch and jump
        jump = false;
    }
}
