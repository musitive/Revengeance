using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDownBlock : MonoBehaviour
{
    // Start is called before the first frame update
    public float fall_speed;
    public float fall_delay;

    bool falltimer_activated = false;
    bool player_is_on_top = false;


    public float max_time_active_until_destroyed;
    private float current_time_until_destroyed;


    GameObject player;
    private float time_until_falling;
    private Vector3 original_position;
    void Start()
    {
        time_until_falling = fall_delay;
        player = GameObject.Find("Player");
        current_time_until_destroyed = max_time_active_until_destroyed;


    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        falltimer_activated = true;
        player_is_on_top = true;


        Debug.Log("YOU TOUCHA DA  BLOCK 2d");
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        player_is_on_top = false;
        Debug.Log("No Longer TOUCHA");
    }


    private void FixedUpdate()
    {
        if (time_until_falling <= 0)
        {        
            float distance = Time.fixedDeltaTime * fall_speed * -1;
            Vector3 translate = new Vector3(0, distance, 0);
            transform.position += translate;
            if(player_is_on_top)
                player.transform.position += translate;

            current_time_until_destroyed -= Time.fixedDeltaTime;
            if (current_time_until_destroyed <= 0)
            {
                Instantiate(gameObject, original_position, transform.rotation);
                Destroy(gameObject);
                
            }
        }
        else if (falltimer_activated)
        {
            time_until_falling -= Time.fixedDeltaTime;
            original_position = transform.position;
        }

    }
}
