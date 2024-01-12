// Ship.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ship : MonoBehaviour
{
    [SerializeField] private AudioSource laserGunEffect;
    Gun[] guns;

    public float moveSpeed = 3;

    bool moveUp;
    bool moveDown;
    bool moveLeft;
    bool moveRight;
    bool speedUp;

    bool shoot;

   
    void Start()
    {
        guns = GetComponentsInChildren<Gun>();
        
    }

    void Update()
    {
        moveUp = Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W);
        moveDown = Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S);
        moveLeft = Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A);
        moveRight = Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D);
        speedUp = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);

        shoot = Input.GetKeyDown(KeyCode.LeftControl);
        if (shoot)
        {
            laserGunEffect.Play();
            shoot = false;
            foreach (Gun gun in guns)
            {
                gun.Shoot();
            }
        }

        

       
    }

    void FixedUpdate()
    {
        Vector2 pos = transform.position;

        float moveAmount = moveSpeed * Time.fixedDeltaTime;
        if (speedUp)
        {
            moveAmount *= 2;
        }
        Vector2 move = Vector2.zero;

        if (moveUp)
        {
            move.y += moveAmount;
        }

        if (moveDown)
        {
            move.y -= moveAmount;
        }
        if (moveLeft)
        {
            move.x -= moveAmount;
        }
        if (moveRight)
        {
            move.x += moveAmount;
        }

        float moveMagnitude = Mathf.Sqrt(move.x * move.x + move.y * move.y);
        if (moveMagnitude > moveAmount)
        {
            float ratio = moveAmount / moveMagnitude;
            move *= ratio;
        }

        pos += move;

        transform.position = pos;
    }

    
}


