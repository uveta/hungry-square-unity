using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public TMP_Text text;

    public void Show(int score)
    {
        text.SetText($"{score} POINTS");
        gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        // resume game
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}