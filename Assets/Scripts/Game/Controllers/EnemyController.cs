using UnityEngine;
using UnityEngine.Events;
using Sirenix.OdinInspector;

public class EnemyController : MonoBehaviour, IDamageable
{
    public GameManager GameManager;

    [TitleGroup("Movement")]
    public float MovementSpeed = 1f;

    [TitleGroup("Loot")]
    public int Point = 1;

    [TitleGroup("Damageable")]
    public int StartHealth = 1;
    public int Health { get; set; }

    public UnityEvent OnDamage { get; } = new UnityEvent();



    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        Health = StartHealth;
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        transform.position += transform.forward * MovementSpeed * Time.deltaTime;
    }



    public void Damage(int damage)
    {
        if (Health > damage)
        {
            Health -= damage;
        }
        else
        {
            Health = 0;
            Die();
        }

        OnDamage.Invoke();
    }

    public void Die()
    {
        GameManager.AddPoint(Point);
        Destroy(gameObject);
    }
}
