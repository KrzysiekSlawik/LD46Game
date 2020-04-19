using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileCulling : MonoBehaviour
{
    public float range = 30;
    private Transform cam;
    private void Start()
    {
        cam = Camera.main.transform;
    }
    private void FixedUpdate()
    {
        if(cam.position.z - transform.position.z > range)
        {
            Destroy(gameObject);
        }
    }
}
