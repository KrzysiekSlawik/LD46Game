using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoUp : MonoBehaviour
{
    public float speed;
    private void FixedUpdate()
    {
        transform.position += Vector3.up * speed;
    }
}
