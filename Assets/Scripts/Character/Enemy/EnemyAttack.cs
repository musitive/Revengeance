using UnityEngine;
using System.Collections;


public class EnemyAttack : MonoBehaviour
{
    public float timeBetweenAttacks = 0.5f;     // The time in seconds between each attack.
    public int attackDamage = 1;               // The amount of health taken away per attack.
    public Octopus octopus;
    public GameObject player;

    Animator anim;                              // Reference to the animator component.
    PlayerHealth playerHealth;                  // Reference to the player's health.
    //EnemyHealth enemyHealth;                    // Reference to this enemy's health.
    bool playerInRange;                         // Whether player is within the trigger collider and can be attacked.
    float timer;                                // Timer for counting up to the next attack.

    /// <summary>
    /// Awake this instance.
    /// </summary>
    void Awake()
    {
        // Setting up the references.
        playerHealth = player.GetComponent<PlayerHealth>();
        //enemyHealth = GetComponent<EnemyHealth>();
        anim = GetComponent<Animator>();
    }

    /// <summary>
    /// Ons the trigger enter.
    /// </summary>
    /// <param name="other">Other.</param>
    void OnCollisionEnter2D(Collision2D other)
    {
        // If the entering collider is the player...
        playerInRange |= other.gameObject == player;
    }

    /// <summary>
    /// Ons the trigger exit.
    /// </summary>
    /// <param name="other">Other.</param>
    void OnCollisionExit2D(Collision2D other)
    {
        // If the exiting collider is the player...
        playerInRange &= other.gameObject != player;
    }

    /// <summary>
    /// Update this instance.
    /// </summary>
    void Update()
    {
        // Add the time since Update was last called to the timer.
        timer += Time.deltaTime;

        // If the timer exceeds the time between attacks, the player is in range and this enemy is alive...
        if (timer >= timeBetweenAttacks && playerInRange)// && enemyHealth.currentHealth > 0)
        {
            // ... attack.
            Attack();
        }

        // If the player has zero or less health...
        if (playerHealth.currentHealth <= 0)
        {
            // ... tell the animator the player is dead.
            anim.SetTrigger("PlayerDead");
        }
    }

    /// <summary>
    /// Attack this instance.
    /// </summary>
    void Attack()
    {
        // Reset the timer.
        timer = 0f;

        // If the player has health to lose...
        if (playerHealth.currentHealth > 0)
        {
            int direction = (player.transform.localPosition.x > octopus.self.localPosition.x) ? 1: -1;
            // ... damage the player.
            playerHealth.TakeDamage(attackDamage, direction);
        }
    }
}
