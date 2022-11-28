using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class EnemyController : MonoBehaviour, IDamageable
{
    [TitleGroup("Movement")]
    public float MovementSpeed = 1f;

    [TitleGroup("Damageable")]
    public int StartHealth = 1;
    public int Health { get; set; }



    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        transform.position += transform.forward * MovementSpeed * Time.deltaTime;
    }



    public void Damage(int damage)
    {
        Health -= damage;
    }
}
