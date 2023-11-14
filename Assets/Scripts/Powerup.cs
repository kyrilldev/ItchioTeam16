using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Powerup : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PickUp(collision);
        }
    }

    private void PickUp(Collider2D collision)
    {
        //give Health
        collision.GetComponent<Health>().canHeal = true;
        DestroySelf();
    }

    private void DestroySelf()
    {
        Destroy(gameObject);
    }
}
