using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRightLeft : MonoBehaviour
{
    public float moveSpeed = 5;
    public float deathPosition = -7.5f; // Position where the enemy should "die"
    private bool hasDied = false; // Flag to ensure EnemyDied() is only called once

    // Reference to the LevelManager
    private LevelManager levelManager;

    // Reference to the ShipHp script
    private ShipHp shipHp;

    private void Start()
    {
        // Find the LevelManager in the scene
        levelManager = FindObjectOfType<LevelManager>();

        // Find the ShipHp script on the player object
        shipHp = FindObjectOfType<ShipHp>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector2 pos = transform.position;

        pos.x -= moveSpeed * Time.deltaTime;

        transform.position = pos;

        // Check if the enemy has reached its death position and hasn't died yet
        if (pos.x < deathPosition && !hasDied)
        {
            // Set the flag to true to avoid calling EnemyDied() multiple times
            hasDied = true;

            // Call EnemyDied in LevelManager
            levelManager.EnemyDied();

            // Apply damage to ShipHp only when it reaches its death position
            if (pos.x <= deathPosition)
            {
                shipHp.TakeDamage(10);
            }

            // Destroy the enemy
            Destroy(gameObject);
        }
    }
}
