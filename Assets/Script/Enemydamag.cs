using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    public int damage = 10;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Hitta skriptet f�r skeppsh�lsa och skada det
            ShipHp shipHealth = other.gameObject.GetComponent<ShipHp>();

            if (shipHealth != null)
            {
                shipHealth.health -= damage;
            }

            // F�rst�r fienden n�r den kolliderar med skeppet
            Destroy(gameObject);
        }
    }
}
