using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class HomingMissile : MonoBehaviour
{
    public string targetTag = "Player"; // Antag att spelaren har taggen "Player"
    public float speed = 5f;
    public float rotateSpeed = 200f;

    private Rigidbody2D rb;
    private Transform target;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        FindTarget();
    }

    void Update()
    {
        if (target == null)
        {
            FindTarget();
            return;
        }

        Vector2 direction = target.position - transform.position;
        direction.Normalize();

        float rotateAmount = Vector3.Cross(direction, transform.up).z;
        rb.angularVelocity = -rotateAmount * rotateSpeed;

        rb.velocity = direction * speed;
    }

    void FindTarget()
    {
        GameObject player = GameObject.FindGameObjectWithTag(targetTag);

        if (player != null)
        {
            target = player.transform;
        }
        else
        {
            target = null;
        }
    }
}
