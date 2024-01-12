using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    public float moveSpeed = 3.0f; // Adjust the speed as needed
    public float upperLimit = 5.0f; // Set the upper limit for movement
    public float lowerLimit = -5.0f; // Set the lower limit for movement

    private int moveDirection = 1; // 1 for moving up, -1 for moving down

    // Update is called once per frame
    void Update()
    {
        MoveUpDown();
    }

    void MoveUpDown()
    {
        // Calculate the new position
        float newY = transform.position.y + moveDirection * moveSpeed * Time.deltaTime;

        // Check if the new position is within the limits
        if (newY > upperLimit)
        {
            newY = upperLimit;
            // Change direction to move down
            moveDirection = -1;
        }
        else if (newY < lowerLimit)
        {
            newY = lowerLimit;
            // Change direction to move up
            moveDirection = 1;
        }

        // Update the position
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
