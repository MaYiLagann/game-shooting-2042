using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Todo: Implement shooting.
    // Todo: Implement use skill.
    // Todo: Implement health and damage.



    public CharacterController PlayerCharacterController;
    public string InputAxisHorizontal = "Horizontal";
    public string InputAxisVertical = "Vertical";

    public float MovementSpeed = 1f;

    public Animator PlayerAnimator;
    public string AnimationKeyMoveLeft = "MoveLeft";
    public string AnimationKeyMoveRight = "MoveRight";

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled
    /// </summary>
    void Update()
    {
        var move = new Vector3(Input.GetAxis(InputAxisHorizontal), 0, Input.GetAxis(InputAxisVertical));

        PlayerCharacterController.Move(move * Time.deltaTime * MovementSpeed);

        PlayerAnimator.SetBool(AnimationKeyMoveLeft, move.x < 0f);
        PlayerAnimator.SetBool(AnimationKeyMoveRight, move.x > 0f);
    }
}
