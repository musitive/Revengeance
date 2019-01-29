using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;

    float horizontalMove = 0f;
    public float runSpeed = 40f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
    }

    void FixedUpdate()
    {
        //fixedDeltaTime assures same speed no matter how frequent this function is called
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, false);// crouch and jump
    }
}
