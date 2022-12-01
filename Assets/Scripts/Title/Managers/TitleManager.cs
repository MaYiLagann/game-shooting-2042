using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    public string GameSceneName = "GameScene";



    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        if (Input.anyKeyDown)
        {
            SceneManager.LoadScene(GameSceneName);
        }
    }
}
