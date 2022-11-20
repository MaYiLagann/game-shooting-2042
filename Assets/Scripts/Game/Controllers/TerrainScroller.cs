using UnityEngine;

public class TerrainScroller : MonoBehaviour
{
    public GameManager GameManager;
    public float MaxScrollHeight;

    private float _scrollHeight;

    /// <summary>
    /// This function is called when the object becomes enabled and active.
    /// </summary>
    void OnEnable()
    {
        _scrollHeight = 0f;
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        if (_scrollHeight > MaxScrollHeight)
        {
            _scrollHeight = 0f;
        }

        _scrollHeight += GameManager.PlayerMovementSpeed * Time.deltaTime;

        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, -_scrollHeight);
    }
}
