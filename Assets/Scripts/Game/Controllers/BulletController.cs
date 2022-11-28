using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public class BulletController : MonoBehaviour
{
    public int Damage = 1;
    public float Speed = 1f;
    public ForceMode BulletForceMode = ForceMode.Force;
    public float MaxRange = 1000f;

    public UnityEvent OnRelease;



    new Rigidbody rigidbody;
    Vector3 startPosition;



    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        startPosition = transform.position;

        rigidbody.AddForce(transform.forward * Speed, BulletForceMode);
    }

    /// <summary>
    /// This function is called when the behaviour becomes disabled or inactive.
    /// </summary>
    void OnDisable()
    {
        rigidbody.velocity = Vector3.zero;
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
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
