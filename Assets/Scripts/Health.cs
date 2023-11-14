using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float healthAmount;
    public float maxHealth = 100;
    public float minHealth = 0;

    private Coroutine healCoroutine;

    public bool canHeal = false;

    private void Start()
    {
        healthAmount = 40;
    }

    private void Update()
    {
        if (healthAmount <= minHealth)
        {
            Die();
        }

        if (canHeal && healCoroutine == null)
        {
            healCoroutine = StartCoroutine(HealSelf());
        }
    }

    private IEnumerator HealSelf()
    {
        canHeal = false;

        float toHeal = maxHealth - healthAmount;
        float hpPerSecond = toHeal / 10;

        for (int i = 0; i < 10; i++)
        {
            if (healthAmount <= 100)
            {
                yield return new WaitForSeconds(0.5f);
                healthAmount += hpPerSecond;
            }
        }
    }

    private void Die()
    {
        Destroy(gameObject);
        //do some more endscreen stuff
    }
}
