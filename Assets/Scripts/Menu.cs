using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void StartButton()
    {
        SceneManager.LoadScene("Game");
    }
}
