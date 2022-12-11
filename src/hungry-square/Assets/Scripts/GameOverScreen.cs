using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void RestartButton()
    {
        // resume game
        Time.timeScale = 1;
        // reload scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}