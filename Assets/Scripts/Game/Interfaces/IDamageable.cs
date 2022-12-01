using UnityEngine.Events;

public interface IDamageable
{
    int Health { get; set; }
    UnityEvent OnDamage { get; }

    void Damage(int damage);
}
