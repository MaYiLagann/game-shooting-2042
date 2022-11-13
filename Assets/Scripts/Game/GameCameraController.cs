using UnityEngine;

public class GameCameraController : MonoBehaviour
{
    public Camera GameCamera;
    public Vector2 ViewSize;

    /// <summary>
    /// This function is called when the object becomes enabled and active.
    /// </summary>
    void OnEnable()
    {
        // Adjust the camera orthographic size for device's screen size.
        var screenSize = new Vector2(Screen.width, Screen.height);

        GameCamera.orthographicSize = ViewSize.x * screenSize.y / screenSize.x / 2f;
    }
}
