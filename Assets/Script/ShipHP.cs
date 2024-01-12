using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShipHp : MonoBehaviour
{
    [SerializeField] private AudioSource palayerDeadeffect;
    public float health;
    public float maxHealth;
    public Image HP;

    void Start()
    {
        maxHealth = health;
    }

    void Update()
    {
        HP.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1);
    }

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        health = Mathf.Max(health, 0); // Ensure health doesn't go below zero

        if (health <= 0)
        {
            Die();
        }
    }

    public void Heal(float healAmount)
    {
        health += healAmount;
        health = Mathf.Min(health, maxHealth); // Ensure health doesn't exceed the maximum
    }

    void Die()
    {

        // Load Game Over-scenen
        SceneManager.LoadScene("GameOver");
    }
}
