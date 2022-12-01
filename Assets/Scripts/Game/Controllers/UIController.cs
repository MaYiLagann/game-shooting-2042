using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    public GameManager GameManager;
    public PlayerController PlayerController;

    public TMP_Text TextPoint;
    public Slider SliderHealth;



    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        GameManager.OnValueChange.AddListener(UpdateUI);
        PlayerController.OnDamage.AddListener(UpdateUI);
    }

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
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
        SliderHealth.value = (float)PlayerController.Health / PlayerController.StartHealth;
    }
}
