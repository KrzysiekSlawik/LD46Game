using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class BasicMonoUtil : MonoBehaviour
{
    public UnityEvent onStart;
    public UnityEvent onDestroy;
    public UnityEvent onClick;
    public UnityEvent onMouseEnter;
    public UnityEvent onMouseExit;
    public UnityEvent onEnable;
    public UnityEvent onDisable;

    public float collisionEventThreshold;
    public UnityEvent onCollisionEnter;


    // Start is called before the first frame update
    void Start()
    {
        onStart.Invoke();
    }
    private void OnDestroy()
    {
        onDestroy.Invoke();
    }
    private void OnDisable()
    {
        onDisable.Invoke();
    }
    private void OnEnable()
    {
        onEnable.Invoke();
    }
    private void OnMouseDown()
    {
        onClick.Invoke();
    }
    private void OnMouseEnter()
    {
        onMouseEnter.Invoke();
    }
    private void OnMouseExit()
    {
        onMouseExit.Invoke();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.impulse.magnitude > collisionEventThreshold)
        {
            onCollisionEnter.Invoke();
        }
    }
    public void Spawn(GameObject prefab)
    {
        Instantiate(prefab, transform.position, transform.rotation);
    }
    public void PlaySound(AudioClip clip)
    {
        AudioSource.PlayClipAtPoint(clip, transform.position);
    }
    public void AddScore(float score)
    {
        Score.Instance().AddScore(score);
    }
    public void LoadScene()
    {
        SceneManager.LoadScene("Game");
    }
}
