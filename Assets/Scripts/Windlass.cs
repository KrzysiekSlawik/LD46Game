using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Windlass : MonoBehaviour
{
    public float state;
    public float step;
    public float stepRotation;
    public float rotationSpeed;
    public float cd;
    private float nextUse;
    public UnityEvent onStateChange;
    public UnityEvent onFullCharge;
    
    public void Activate()
    {
        if(state != 1 && nextUse <= Time.time)
        {
            nextUse = Time.time + cd;
            state = Mathf.Clamp(state + step, 0, 1);
            if (state == 1)
            {
                onFullCharge.Invoke();
            }
            onStateChange.Invoke();
        }
    }
    private void FixedUpdate()
    {
        transform.rotation = Quaternion.RotateTowards(transform.rotation, 
                             Quaternion.Euler(state * stepRotation, 0, 0), rotationSpeed);
    }
}
