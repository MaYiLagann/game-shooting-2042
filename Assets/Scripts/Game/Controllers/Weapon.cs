using UnityEngine;
using UnityEngine.Pool;
using Sirenix.OdinInspector;

public class Weapon : MonoBehaviour
{
    [AssetsOnly]
    public BulletController BulletPrefab;
    public IObjectPool<BulletController> BulletPool { get; set; }
    [ChildGameObjectsOnly]
    public Transform ShootTransform;
    [MinValue(1)]
    public int ShootPerSeconds = 1;



    float shootTimer = 0f;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        BulletPool = new ObjectPool<BulletController>(
            createFunc: () => Instantiate(BulletPrefab),
            actionOnGet: bullet => bullet.gameObject.SetActive(true),
            actionOnRelease: bullet =>
            {
                bullet.Remover.OnRemove.RemoveAllListeners();
                bullet.gameObject.SetActive(false);
            },
            actionOnDestroy: bullet => Destroy(bullet),
            maxSize: 100
        );
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        if (shootTimer <= 0f)
        {
            shootTimer = 1f / ShootPerSeconds;

            var bullet = BulletPool.Get();
            bullet.transform.position = ShootTransform.position;
            bullet.transform.rotation = ShootTransform.rotation;
            bullet.Remover.OnRemove.AddListener(() => BulletPool.Release(bullet));
        }

        shootTimer -= Time.deltaTime;
    }
}
