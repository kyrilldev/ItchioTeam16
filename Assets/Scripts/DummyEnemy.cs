using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyEnemy : MonoBehaviour
{
    private Health health;

    private void Start()
    {
        health = GetComponent<Health>();
    }

    private void Update()
    {
        if (health.healthAmount <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
