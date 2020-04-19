using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public Windlass windlass;
    private float state;
    public Vector3 translation;
    private Vector3 originalPos;
    public float translationSpeed;
    private void Start()
    {
        originalPos = transform.position;
    }
    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, originalPos + translation * state, translationSpeed);
    }
    public void UpdateState()
    {
        state = windlass.state;
    }
}
