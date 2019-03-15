using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : MonoBehaviour
{
    private Transform player;
    private Transform self;
    
    public float runSpeed = 3f;
    float elapsedTime = 0;
    public float oscillatingSpeed = 10f;
    public float oscillatingHeight = .5f;
    float sightDistance = 10f; //beyond this the enemy cannot see the player

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        self = new GameObject().transform;
        self.position = transform.position;
    }


    void Update()
    {
        elapsedTime += Time.deltaTime;

        self.LookAt(player.position);
        self.Rotate(new Vector3(0, -90, 0), Space.Self);//correcting the original rotation
 
        //move towards the player
        if (Vector3.Distance(self.position, player.position) < sightDistance)
        {//move if distance from target is greater than 1
            self.Translate(new Vector3(runSpeed * Time.deltaTime, 0, 0));
            transform.position = self.position;
        }
        transform.position = new Vector3(self.position.x, self.position.y + Mathf.Sin(elapsedTime * oscillatingSpeed) * oscillatingHeight, self.position.z);
    }
}
