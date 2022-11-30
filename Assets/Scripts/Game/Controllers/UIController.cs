using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    public GameManager GameManager;

    public TMP_Text TextPoint;



    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        GameManager.OnValueChange.AddListener(UpdateUI);

        UpdateUI();
    }

    /// <summary>
    /// This function is called when the MonoBehaviour will be destroyed.
    /// </summary>
    void OnDestroy()
    {
        GameManager.OnValueChange.RemoveListener(UpdateUI);
    }

    void UpdateUI()
    {
        TextPoint.SetText(GameManager.Point.ToString());
    }
}
