using UnityEngine;
using UnityEngine.Pool;
using Sirenix.OdinInspector;

public class Weapon : MonoBehaviour
{
    [AssetsOnly]
    public BulletController BulletPrefab;
    public IObjectPool<BulletController> BulletPool { get; set; }
    [ChildGameObjectsOnly]
    public Transform[] ShootTransforms;
    [MinValue(1)]
    public int ShootPerSeconds = 1;



    float shootTimer = 0f;
    int shootIndex = 0;



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
        if (ShootTransforms.Length == 0)
            return;

        if (shootTimer <= 0f)
        {
            shootTimer = 1f / ShootPerSeconds;
            Shoot();
        }

        shootTimer -= Time.deltaTime;
    }

    void Shoot()
    {
        var transform = ShootTransforms[shootIndex++];
        if (shootIndex >= ShootTransforms.Length)
        {
            shootIndex = 0;
        }

        var bullet = BulletPool.Get();
        bullet.transform.position = transform.position;
        bullet.transform.rotation = transform.rotation;
        bullet.Remover.OnRemove.AddListener(() => BulletPool.Release(bullet));
    }
}
