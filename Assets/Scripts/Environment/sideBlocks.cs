using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sideBlocks : MonoBehaviour
{
    public float horizontal_speed;
    public float fall_delay;
    private float time_until_falling;
    bool falltimer_activated = false;
    bool player_is_on_top = false;

    public float max_time_active_until_destroyed;
    private float current_time_until_destroyed;

    GameObject player;
    private Vector3 original_position;
    void Start()
    {
        time_until_falling = fall_delay;
        player = GameObject.Find("Player");
        current_time_until_destroyed = max_time_active_until_destroyed;
        original_position = transform.position;
    }

    //When player touches block, start timer
    private void OnCollisionEnter2D(Collision2D collision)
    {
        falltimer_activated = true;
        player_is_on_top = true;


        Debug.Log("YOU TOUCHA DA  BLOCK 2d");
    }

    //When player is no longer touching it, no longer consider playing ontop so the player doesnt move with it
    private void OnCollisionExit2D(Collision2D collision)
    {
        player_is_on_top = false;
        Debug.Log("No Longer TOUCHA");
    }

    //if the delay timer is up, make block move and make player move with it
    //if the time limit is up destroy it
    //if the player touched the block and it hasnt started falling, advance delay timer
    private void FixedUpdate()
    {
        if (time_until_falling <= 0)
        {
            float distance = Time.fixedDeltaTime * horizontal_speed * -1;
            Vector3 translate = new Vector3(distance, 0, 0);
            transform.position += translate;
            if (player_is_on_top)
                player.transform.position += translate;

            current_time_until_destroyed -= Time.fixedDeltaTime;
            if(current_time_until_destroyed <= 0)
            {
                Instantiate(gameObject, original_position, transform.rotation);
                Destroy(gameObject);
            }
        }
        else if (falltimer_activated)
        {
            time_until_falling -= Time.fixedDeltaTime;
        }

    }
}
