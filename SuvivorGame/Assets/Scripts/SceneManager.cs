using UnityEngine;
using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;

public class SceneManager : MonoBehaviour
{
    [SerializeField]
    private GameObject GameOverUI;

    public void LoadGame()
    {
        UnitySceneManager.LoadScene("GameScene");
    }

    public void LoadStartScene()
    {
        UnitySceneManager.LoadScene("StartScene");
    }

    public void GameOver()
    {
        GameOverUI.SetActive(true);
    }
}
