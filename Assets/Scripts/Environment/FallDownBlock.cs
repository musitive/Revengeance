using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDownBlock : MonoBehaviour
{
    // Start is called before the first frame update
    public float fall_speed;
    public float fall_delay;
    private float time_until_falling;
    bool falltimer_activated = false;
    bool player_is_on_top = false;

    GameObject player;
    void Start()
    {
        time_until_falling = fall_delay;
        player = GameObject.Find("Player");
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
        }
        else if (falltimer_activated)
        {
            time_until_falling -= Time.fixedDeltaTime;            
        }

    }
}
