using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaController : MonoBehaviour
{
    public float AreaWidth;

    /// <summary>
    /// This function is called when the object becomes enabled and active.
    /// </summary>
    void OnEnable()
    {
        // Adjust the area size for device's screen size.
        var screenSize = new Vector2(Screen.width, Screen.height);

        transform.localScale = new Vector3(AreaWidth, transform.localScale.y, AreaWidth * screenSize.y / screenSize.x);
    }
}
