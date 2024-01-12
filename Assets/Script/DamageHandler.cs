using UnityEngine;

public class DamageHandler : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    private void Start()
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

    private void Die()
    {
        // Placera kod h�r f�r vad som ska h�nda n�r objektet d�r
        Destroy(gameObject);
    }
}
