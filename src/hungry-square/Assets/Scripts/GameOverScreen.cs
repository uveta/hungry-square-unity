using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public TMP_Text text;

    public void Show(int score)
    {
        text.SetText($"GAME OVER, SCORE {score}");
        gameObject.SetActive(true);
    }

    public void RestartButton()
    {
        // resume game
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}