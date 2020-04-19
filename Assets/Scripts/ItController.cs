using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItController : MonoBehaviour
{
    public float speed;
    private bool isWalking;
    private Animator animator;
    private Rigidbody rb;
    public UnityEvent onStartWalk;
    public UnityEvent onStopWalk;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        bool blocked = Physics.Raycast(transform.position + Vector3.up * 0.4f, transform.forward, 0.5f);
        if(!blocked)
        {
            blocked = Physics.Raycast(transform.position + Vector3.up * 1.77f, transform.forward, 0.5f);
        }
        if(isWalking && !blocked)
        {
            rb.velocity = Vector3.forward * speed + Vector3.up * rb.velocity.y;
            animator.SetBool("IsWalking", true);
        }
        else
        {
            rb.velocity = Vector3.up * rb.velocity.y;
            animator.SetBool("IsWalking", false);
        }
    }
    public void SwitchWalking()
    {
        isWalking = !isWalking;
        if(isWalking)
        {
            onStartWalk.Invoke();
        }
        else
        {
            onStopWalk.Invoke();
        }
    }
}
