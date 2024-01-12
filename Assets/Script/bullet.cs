using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5f;
    public int bulletDamage = 10;
    

    private void Start()
    {
        // Ställ in initialhastigheten för att röra kulan framåt
        GetComponent<Rigidbody2D>().velocity = transform.right * speed;

        

    }

    void Update()
    {
        // Kolla om skottet har nått eller passerat den önskade X-koordinaten
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        HandleCollision(collision.collider);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        HandleCollision(other);
    }

    private void HandleCollision(Collider2D collider)
    {
        // Kontrollera om det kolliderande objektet har komponenten EnemyHealth
        EnemyHealth enemyHealth = collider.GetComponent<EnemyHealth>();

        if (enemyHealth != null)
        {
            // Tillämpa skada på fienden
            enemyHealth.TakeDamage(bulletDamage);

            // Förstör kulan efter att ha skadat fienden
            Destroy(gameObject);
        }
        
    }
}
