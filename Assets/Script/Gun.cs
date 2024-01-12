// Gun.cs
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Bullet bullet;
    Vector2 direction;

    public bool autoShoot = false;
    public float shootIntervalSeconds = 0.5f;
    public float shootDelaySeconds = 0.0f;
    public float shootTimer = 0f;
    public float delayTimer = 0f;

    public bool isActive = false;

    void Update()
    {
        if (!isActive)
        {
            return;
        }

        direction = (transform.localRotation * Vector2.right).normalized;

        if (autoShoot)
        {
            if (delayTimer >= shootDelaySeconds)
            {
                if (shootTimer >= shootIntervalSeconds)
                {
                    Shoot();
                    shootTimer = 0;
                }
                else
                {
                    shootTimer += Time.deltaTime;
                }
            }
            else
            {
                delayTimer += Time.deltaTime;
            }
        }
    }

    public void Shoot()
    {
        Instantiate(bullet.gameObject, transform.position, Quaternion.identity);
    }
}

