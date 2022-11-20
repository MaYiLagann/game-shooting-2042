using UnityEngine;

public class BulletController : MonoBehaviour
{
    public int Damage = 1;
    public float Speed = 1f;



    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        transform.position += transform.forward * Speed * Time.deltaTime;
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
