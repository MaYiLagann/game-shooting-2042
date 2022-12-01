using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    public GameManager GameManager;
    public PlayerController PlayerController;

    public TMP_Text TextPoint;
    public Slider SliderHealth;
    public GameObject GameOver;



    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        GameManager.OnValueChange.AddListener(UpdateUI);
        PlayerController.OnDamage.AddListener(UpdateUI);
    }

    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    void FixedUpdate()
    {
        UpdateUI();
    }

    /// <summary>
    /// This function is called when the MonoBehaviour will be destroyed.
    /// </summary>
    void OnDestroy()
    {
        GameManager.OnValueChange.RemoveListener(UpdateUI);
        PlayerController.OnDamage.RemoveListener(UpdateUI);
    }

    void UpdateUI()
    {
        TextPoint.SetText(GameManager.Point.ToString());
        SliderHealth.value = (float)PlayerController.Health / PlayerController.StartHealth;
        GameOver.SetActive(PlayerController.Health <= 0);
    }
}
