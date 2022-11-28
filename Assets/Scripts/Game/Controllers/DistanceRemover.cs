using UnityEngine;
using UnityEngine.Events;
using Sirenix.OdinInspector;

public class DistanceRemover : MonoBehaviour
{
    public float MaxRange = 1000f;
    public bool DestroySelf = false;

    [ShowIf("@DestroySelf == false")]
    public UnityEvent OnRemove;



    Vector3 startPosition;



    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        startPosition = transform.position;
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        if (Vector3.Distance(startPosition, transform.position) > MaxRange)
        {
            transform.position = startPosition;

            if (DestroySelf)
            {
                Destroy(gameObject);
            }
            else
            {
                OnRemove.Invoke();
            }
        }
    }
}
