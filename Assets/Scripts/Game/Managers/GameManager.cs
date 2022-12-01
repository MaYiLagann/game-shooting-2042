using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Sirenix.OdinInspector;

using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public float PlayerMovementSpeed = 1f;

    [TitleGroup("Enemy Spawner")]
    [AssetsOnly]
    public List<EnemyController> ListPrefabEnemy;
    public Transform EnemySpawnArea;
    public Vector2 EnemySpawnDelay;

    public UnityEvent OnValueChange;



    [NonSerialized]
    public int Point = 0;



    private float enemySpawnTimer = 0f;



    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        if (enemySpawnTimer <= 0f)
        {
            EnemySpawn();
            enemySpawnTimer = Random.Range(EnemySpawnDelay.x, EnemySpawnDelay.y);
        }

        enemySpawnTimer -= Time.deltaTime;
    }



    public void AddPoint(int point)
    {
        Point += point;

        OnValueChange.Invoke();
    }

    public void EnemySpawn()
    {
        var spawnPosition = new Vector3(
            Random.Range(-EnemySpawnArea.localScale.x, EnemySpawnArea.localScale.x) + EnemySpawnArea.position.x,
            Random.Range(-EnemySpawnArea.localScale.y, EnemySpawnArea.localScale.y) + EnemySpawnArea.position.y,
            Random.Range(-EnemySpawnArea.localScale.z, EnemySpawnArea.localScale.z) + EnemySpawnArea.position.z
        );

        var enemyPrefab = ListPrefabEnemy[Random.Range(0, ListPrefabEnemy.Count)];
        var enemy = Instantiate(enemyPrefab, spawnPosition, enemyPrefab.transform.rotation);
        enemy.GameManager = this;
    }
}
