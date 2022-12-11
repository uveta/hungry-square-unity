using UnityEngine;

public class GameController : MonoBehaviour
{
    public float gameSpeed = 3.0f;
    public float gameSpeedIncrement = 5;
    public GameOverScreen gameOverScreen;
    private int _score;

    public float GameSpeed => gameSpeed;

    public void GameOver()
    {
        // pause game
        Time.timeScale = 0;
        // show Game Over screen
        gameOverScreen.Show(_score);
    }

    public void IncreaseScore(int count = 1)
    {
        _score += count;
    }

    public void IncreaseSpeed()
    {
        gameSpeed *= 1 + gameSpeedIncrement / 100;
    }
}