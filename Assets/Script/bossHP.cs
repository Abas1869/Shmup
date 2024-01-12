using UnityEngine;

public class BossHP : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    void Start()
    {
        // Initialisera bossens h�lsa vid start
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        // Minska h�lsan n�r bossen tar skada
        currentHealth -= damageAmount;

        // Kontrollera om bossen �r d�d efter att ha tagit skada
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public bool IsDead()
    {
        // Returnera true om bossen �r d�d, annars false
        return currentHealth <= 0;
    }

    private void Die()
    {
        // L�gg till annan logik h�r som ska utf�ras n�r bossen d�r

        // Till exempel, om du vill att bossen ska f�rst�ras n�r den d�r:
        Destroy(gameObject);
    }
}
