using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Octopus : MonoBehaviour
{
    public CharacterController2D controller;
    private Transform player;

    float horizontalMove = 30f;
    public float runSpeed = 30f;
    float sightDistance = 10; //beyond this the enemy cannot see the player

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }


    /// <summary>
    /// Update this instance.  Update is called once per frame.
    /// </summary>
    void Update()
    {
        if (Vector3.Distance(transform.position, player.position) > sightDistance)
        {
            horizontalMove = 0;
            return;
        }
        if (player.localPosition.x < transform.localPosition.x)
        {
            horizontalMove = -1 * runSpeed;
        }
        else
        {
            horizontalMove = runSpeed;
        }
    }

    /// <summary>
    /// Fixeds the update.
    /// </summary>
    void FixedUpdate()
    {
        //fixedDeltaTime assures same speed no matter how frequent this function is called
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, false);// crouch and jump
    }
}
