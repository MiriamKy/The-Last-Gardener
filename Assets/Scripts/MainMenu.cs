using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void Play()
    {
        SceneManager.LoadScene("Game");
    }

    public void Settings()
    {

    }

    public void Quit()
    {
        Application.Quit();
    }
}