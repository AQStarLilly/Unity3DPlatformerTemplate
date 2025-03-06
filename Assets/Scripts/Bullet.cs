using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int bulletDamage = 1; // Damage dealt by the bullet
    public float bulletLifetime = 3f; // Lifetime before bullet is destroyed

    void Start()
    {
        Destroy(gameObject, bulletLifetime); // Auto-destroy bullet after set time
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the object has a HealthController component
        HealthController health = other.GetComponent<HealthController>();

        if (health != null)
        {
            health.ApplyDamage(bulletDamage); // Apply damage to the object
            Destroy(gameObject); // Destroy the bullet upon impact
        }
    }
}
