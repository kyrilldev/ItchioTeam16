using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform followObject;

    private void Update()
    {
        Vector3 currentPos = followObject.position;
        currentPos.z = gameObject.transform.position.z;

        gameObject.transform.position = currentPos;
    }
}
