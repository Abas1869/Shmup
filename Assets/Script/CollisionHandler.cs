using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    public int damage = 10;

    private void OnCollisionEnter2D(Collision2D other)
    {
        DamageHandler damageHandler = other.gameObject.GetComponent<DamageHandler>();

        if (damageHandler != null)
        {
            damageHandler.TakeDamage(damage);
        }
    }
}
