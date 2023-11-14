using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public string dontDestroyTag;
    public float speed;

    private void Update()
    {
        gameObject.transform.position -= speed * Time.deltaTime * gameObject.transform.up;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag(dontDestroyTag))
        {
            Destroy(gameObject);
        }
    }
}
