using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Processors;

public class EnemyDamage : MonoBehaviour
{
    public int damageAmount = 10; // Skadam�ngd som fienden orsakar
  
    void OnTriggerEnter2D(Collider2D other)
    {
        // Kolla om triggerkollisionen har skett med ett objekt som har taggen "Player"
        if (other.CompareTag("Player"))
        {
            // Om kollision med spelaren, anropa TakeDamage p� rymdskeppets skadekomponent.
            other.GetComponent<ShipHp>().TakeDamage(damageAmount);

            // F�rst�r fienden efter att skadan har applicerats
            
            Destroy(gameObject);
        }
    }
}
