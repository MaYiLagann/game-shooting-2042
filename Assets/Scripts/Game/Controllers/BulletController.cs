using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BulletController : MonoBehaviour
{
    public int Damage = 1;
    public float Speed = 1f;
    public ForceMode BulletForceMode = ForceMode.Force;

    public DistanceRemover Remover;



    new Rigidbody rigidbody;



    /// <summary>
    /// This function is called when the object becomes enabled and active.
    /// </summary>
    void OnEnable()
    {
        rigidbody = GetComponent<Rigidbody>();

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
