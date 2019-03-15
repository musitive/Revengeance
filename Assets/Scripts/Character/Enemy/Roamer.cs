using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roamer : MonoBehaviour
{
    public CharacterController2D controller;
    private Vector3 startingPosition;

    float horizontalMove = 30f;
    public float runSpeed = 10f;
    public float walkingDistance = 2f;
    bool walkingRight = true;
    bool jump = false;//currently not used, but can be in the future

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
    }


    /// <summary>
    /// Update this instance.  Update is called once per frame.
    /// </summary>
    void Update()
    {
        if (walkingRight)
        {
            horizontalMove = -1 * runSpeed;
        }
        else
        {
            horizontalMove = runSpeed;
        }
        if (!walkingRight && transform.position.x - startingPosition.x > walkingDistance)
        {
            walkingRight = true;
        }
        else if (walkingRight && startingPosition.x - transform.position.x > walkingDistance)
        {
            walkingRight = false;
        }
    }

    /// <summary>
    /// Fixeds the update.
    /// </summary>
    void FixedUpdate()
    {
        //fixedDeltaTime assures same speed no matter how frequent this function is called
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);// crouch and jump
    }
}
