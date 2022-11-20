using UnityEngine;
using Sirenix.OdinInspector;

public class PlayerController : MonoBehaviour, IDamageable
{
    // Todo: Implement use skill.



    [TitleGroup("Movement")]
    [ChildGameObjectsOnly]
    public CharacterController PlayerCharacterController;
    public string InputAxisHorizontal = "Horizontal";
    public string InputAxisVertical = "Vertical";

    public float MovementSpeed = 1f;

    [TitleGroup("Animation")]
    [ChildGameObjectsOnly]
    public Animator PlayerAnimator;
    public string AnimationKeyMoveLeft = "MoveLeft";
    public string AnimationKeyMoveRight = "MoveRight";

    [TitleGroup("Damageable")]
    public int StartHealth = 100;
    public int Health { get; set; }

    [TitleGroup("Shooting")]
    [AssetsOnly]
    public BulletController BulletPrefab;
    [ChildGameObjectsOnly]
    public Transform ShootTransform;
    public float ShootDelay = 0f;



    float shootTimer = 0f;



    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        Health = StartHealth;
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled
    /// </summary>
    void Update()
    {
        var move = new Vector3(Input.GetAxis(InputAxisHorizontal), 0, Input.GetAxis(InputAxisVertical));

        PlayerCharacterController.Move(move * Time.deltaTime * MovementSpeed);

        PlayerAnimator.SetBool(AnimationKeyMoveLeft, move.x < 0f);
        PlayerAnimator.SetBool(AnimationKeyMoveRight, move.x > 0f);

        if (shootTimer <= 0f)
        {
            shootTimer = ShootDelay;

            var bullet = Instantiate(BulletPrefab);
            bullet.transform.position = ShootTransform.position;
            bullet.transform.rotation = ShootTransform.rotation;
        }

        shootTimer -= Time.deltaTime;
    }

    public void Damage(int damage)
    {
        Health -= damage;
    }
}
