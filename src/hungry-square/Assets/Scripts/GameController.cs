using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameOverScreen gameOverScreen;

    public void GameOver()
    {
        // pause game
        Time.timeScale = 0;
        // show Game Over screen
        gameOverScreen.Setup();
    }
}