using UnityEngine;

public class BossHP : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    void Start()
    {
        // Initialisera bossens hälsa vid start
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        // Minska hälsan när bossen tar skada
        currentHealth -= damageAmount;

        // Kontrollera om bossen är död efter att ha tagit skada
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public bool IsDead()
    {
        // Returnera true om bossen är död, annars false
        return currentHealth <= 0;
    }

    private void Die()
    {
        // Lägg till annan logik här som ska utföras när bossen dör

        // Till exempel, om du vill att bossen ska förstöras när den dör:
        Destroy(gameObject);
    }
}
