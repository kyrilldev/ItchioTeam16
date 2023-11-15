using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed;
    public float RaycastRadius;
    public float DamageAmount;
    public float AttackRadius;

    public Transform AttackTransform;

    public LayerMask attackableLayer;

    public float AttackTimer;
    public float TimeBtwAttacks;

    public RaycastHit2D[] hits;

    public Animator animator;

    Vector3 Gizmopos;

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            gameObject.transform.position += Speed * Time.deltaTime * Vector3.up;
        }
        if (Input.GetKey(KeyCode.A))
        {
            gameObject.transform.position -= Speed * Time.deltaTime * Vector3.right;
        }
        if (Input.GetKey(KeyCode.S))
        {
            gameObject.transform.position -= Speed * Time.deltaTime * Vector3.up;
        }
        if (Input.GetKey(KeyCode.D))
        {
            gameObject.transform.position += Speed * Time.deltaTime * Vector3.right;
        }

        if (Input.GetKey(KeyCode.Mouse0) && AttackTimer >= TimeBtwAttacks)
        {
            animator.SetInteger("Swing", 1);

            StartCoroutine(SwingBack());

            Attack();
        }

        AttackTimer += Time.deltaTime;
    }

    private void Attack()
    {
        hits = Physics2D.CircleCastAll(AttackTransform.position, AttackRadius, AttackTransform.transform.right, 0, attackableLayer);

        Debug.Log("Amount of hits: " + hits.Length);

        for (int i = 0; i < hits.Length; i++)
        {
            Health health = hits[i].collider.gameObject.GetComponent<Health>();

            Gizmopos = hits[i].transform.position;

            if (health != null)
            {
                health.healthAmount -= DamageAmount;
            }
        }

        AttackTimer = 0;

    }

    private IEnumerator SwingBack()
    {
        yield return new WaitForSeconds(0.1f);
        animator.SetInteger("Swing", 0);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(Gizmopos, AttackRadius);
    }
}
