using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameover = false;
    public float restartDelay = 1f;
    public GameOverScreen gameOverScreen;
    public int health = 10;
    public int multiplier = 1;
    public int BPM = 120;
    public float tolerance = 0.1f;

    public float secPerBeat;

    private void Start()
    {
        secPerBeat = 60f / BPM;
    }

    void GameOver()
    {
        if(!gameover)
        {
            gameover = true;
            Time.timeScale = 0f;
            gameOverScreen.Setup();
        }
    }

    public void manageMultiplier(float previousShotTime, float currentTime)
    {
        float rythm = currentTime - previousShotTime;
        if (rythm - secPerBeat <= tolerance && secPerBeat - rythm <= tolerance)
        {
            increaseMultiplier();
        } else
        {
            decreaseMultiplier();
        }
    }

    public void increaseMultiplier()
    {
        if(multiplier < 10)
        {
            multiplier += 1;
            FindObjectOfType<UI>().setMultiplier(multiplier);
        }
    }

    public void decreaseMultiplier()
    {
        if (multiplier > 1)
        {
            multiplier -= 1;
            FindObjectOfType<UI>().setMultiplier(multiplier);
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