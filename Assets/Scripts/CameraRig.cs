using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRig : MonoBehaviour
{
    public Transform target;
    public AnimationCurve overDistanceSpeed;
    // Update is called once per frame
    void Update()
    {
        if(target != null)
        {
            float distance = Vector3.Distance(target.position, transform.position);
            transform.position = Vector3.MoveTowards(transform.position, target.position,
                                                        overDistanceSpeed.Evaluate(distance)*Time.deltaTime);
        }
    }
}
