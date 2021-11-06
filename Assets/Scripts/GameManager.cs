using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameover = false;
    public float restartDelay = 1f;
    public GameOverScreen gameOverScreen;
    public int health = 10;

    void GameOver()
    {
        if(!gameover)
        {
            Debug.Log("Game Over");
            gameover = true;
            Time.timeScale = 0f;
            gameOverScreen.Setup();
        }
    }

    public void increaseHealth()
    {
        health += 1;
    }

    public void decreaseHealth()
    {
        health -= 1;
        if (health <= 0)
        {
            GameOver();
        }
    }
}
