using UnityEngine.Events;

public interface IDamageable
{
    string Tag { get; }
    int Health { get; set; }
    UnityEvent OnDamage { get; }

    void Damage(int damage);
}
