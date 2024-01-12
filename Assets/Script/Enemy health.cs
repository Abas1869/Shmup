// EnemyHealth.cs
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    public bool isBoss = false;


    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
       

        // Meddela LevelManager att en fiende har d�tt
        FindObjectOfType<LevelManager>()?.EnemyDied();

        // F�rst�r fienden
       
        Destroy(gameObject);
    }
}
