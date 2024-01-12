using UnityEngine;

public class BadMedkit : MonoBehaviour
{
    public int damageAmount = 20; // Skadans mängd som Bad Medkit kommer att orsaka

    void Start()
    {
        // Schedule the destruction of the BadMedkit after 5 seconds
        Invoke("DestroyItem", 5f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Orsaka skada åt spelaren
            ShipHp playerHealth = other.GetComponent<ShipHp>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount);
            }

            // Förstör Bad Medkit efter att ha orsakat skada
            Destroy(gameObject);
        }
    }

    void DestroyItem()
    {
        // Destroy the BadMedkit
        Destroy(gameObject);
    }
}