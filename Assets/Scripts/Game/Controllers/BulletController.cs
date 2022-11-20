using UnityEngine;
using UnityEngine.Events;

public class BulletController : MonoBehaviour
{
    public int Damage = 1;
    public float Speed = 1f;
    public float MaxRange = 1000f;

    public UnityEvent OnRelease;



    Vector3 startPosition;



    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        startPosition = transform.position;
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        transform.position += transform.forward * Speed * Time.deltaTime;

        if (Vector3.Distance(startPosition, transform.position) > MaxRange)
        {
            transform.position = startPosition;
            OnRelease.Invoke();
        }
    }



    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerEnter(Collider other)
    {
        var damageable = other.GetComponent<IDamageable>();
        if (damageable != null)
        {
            damageable.Damage(Damage);
        }
    }
}
