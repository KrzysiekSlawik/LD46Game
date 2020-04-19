using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public int health;
    public UnityEvent onDamaged;
    public UnityEvent onDestroyed;

    public void Attack()
    {
        health--;
        onDamaged.Invoke();
        if(health <= 0)
        {
            onDestroyed.Invoke();
            Destroy(gameObject);
        }
    }
}
