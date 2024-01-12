using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5f;
    public int bulletDamage = 10;
    

    private void Start()
    {
        // St�ll in initialhastigheten f�r att r�ra kulan fram�t
        GetComponent<Rigidbody2D>().velocity = transform.right * speed;

        

    }

    void Update()
    {
        // Kolla om skottet har n�tt eller passerat den �nskade X-koordinaten
       
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
            // Till�mpa skada p� fienden
            enemyHealth.TakeDamage(bulletDamage);

            // F�rst�r kulan efter att ha skadat fienden
            Destroy(gameObject);
        }
        
    }
}
