using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed;

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
    }
}
