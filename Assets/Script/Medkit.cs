using UnityEngine;

public class HealingItem : MonoBehaviour
{
    public float healAmount = 20; // Set the amount of healing provided

    void Start()
    {
        // Schedule the destruction of the HealingItem after 5 seconds
        Invoke("DestroyItem", 5f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the player has collided with the healing item
        if (other.CompareTag("Player"))
        {
            // Call the Heal method on the player's ShipHp script
            other.GetComponent<ShipHp>().Heal(healAmount);

            // Destroy the healing item
            Destroy(gameObject);
        }
    }

    void DestroyItem()
    {
        // Destroy the HealingItem
        Destroy(gameObject);
    }
}
