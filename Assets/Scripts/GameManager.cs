using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool gameover = false;
    public float restartDelay = 1f;
    public GameOverScreen gameOverScreen;
    public int health = 10;
    public int multiplier = 1;
    public int BPM = 120;
    public float tolerance = 0.1f;
    public int laser;
    public float secPerBeat;
    public int shootChain = 10;
    public int score;
    public MobileProperties mobileProperties;
    public Canvas mobileUI;

    private void Start()
    {
        secPerBeat = 60f / BPM;
        laser = 0;
        if(mobileProperties.isMobile())
        {
            mobileUI.gameObject.SetActive(true);
        }
    }

    public void GameOver()
    {
        if(!gameover)
        {
            GetComponents<AudioSource>()[2].Play();
            DangerZone[] dangerZones = FindObjectsOfType<DangerZone>();
            foreach(DangerZone dangerZone in dangerZones) {
              dangerZone.GetComponent<AudioSource>().Stop();
            }
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
        laser += 1;
        if (laser % shootChain == 0)
        {
            FindObjectOfType<Weapon>().Laser();
        }
    }

    public void decreaseMultiplier()
    {
        if (multiplier > 1)
        {
            multiplier -= 1;
            FindObjectOfType<UI>().setMultiplier(multiplier);
        }
        laser = 0;
    }

    public void increaseHealth()
    {
        health += 1;
        FindObjectOfType<UI>().setHealth(health);
    }

    public void decreaseHealth()
    {
        health -= 1;
        FindObjectOfType<UI>().setHealth(health);
        if (health <= 0)
        {
            GameOver();
        }
    }

    public void incrementScore() {
      score++;
      FindObjectOfType<UI>().setScore(score);
    }
}
