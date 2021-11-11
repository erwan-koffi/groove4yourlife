using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public MobileProperties mobile;

    public void StartButton()
    {
        SceneManager.LoadScene("Game");
    }
}
