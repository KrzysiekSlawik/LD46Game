using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LooseStone : MonoBehaviour
{
    private Rigidbody rb;
    public float timeToFall;
    public AudioClip fallSound;
    public UnityEvent onPlayerStepOn;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player") && !IsInvoking("Fall"))
        {
            onPlayerStepOn.Invoke();
            Invoke("Fall", timeToFall);
            AudioSource.PlayClipAtPoint(fallSound, transform.position);
            transform.position += Vector3.up * -0.2f;
        }
    }
    private void Fall()
    {
        rb.isKinematic = false;
        AudioSource.PlayClipAtPoint(fallSound, transform.position);
    }
}
