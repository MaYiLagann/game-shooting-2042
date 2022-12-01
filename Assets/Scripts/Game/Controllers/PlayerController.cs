using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
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
    public string AnimationKeyDead = "Dead";

    [TitleGroup("Damageable")]
    public int StartHealth = 100;
    public int Health { get; set; }

    public UnityEvent OnDamage { get; } = new UnityEvent();

    [TitleGroup("Weapon")]
    public Weapon Weapon;



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
        if (Health > 0)
        {
            var move = new Vector3(Input.GetAxis(InputAxisHorizontal), 0, Input.GetAxis(InputAxisVertical));

            PlayerCharacterController.Move(move * Time.deltaTime * MovementSpeed);

            PlayerAnimator.SetBool(AnimationKeyMoveLeft, move.x < 0f);
            PlayerAnimator.SetBool(AnimationKeyMoveRight, move.x > 0f);
        }
        else
        {
            if (Input.anyKey)
            {
                SceneManager.LoadScene(gameObject.scene.name);
            }
        }
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
        Weapon.enabled = false;
        PlayerAnimator.SetTrigger(AnimationKeyDead);
    }
}
