using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    // Referanse til PauseMenu gameobjektet v�rt. Dette er panelet vi vil skru av og p�
    [SerializeField] private GameObject pauseMenu;

    // En m�te � se om spillet er pauset eller ikke
    private bool isPaused = false;


    // P� hver frame har lyst til � se om spilleren har trykket p� escape
    private void Update()
    {

        // Hvis spilleren har trykket p� escape, s� vil gj�re noe
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            // Hvis spilleren v�r trykker p� escape og spillet IKKE er pauset, gj�r:
            if (!isPaused)
            {

                // Aktiver menyen v�r
                pauseMenu.SetActive(true);
                // Stoppe tiden
                Time.timeScale = 0;
                // Sett isPaused til true
                isPaused = true;

            }
            else
            {
                // Hvis spilleren p� escape og spillet ER pauset, gj�r: 
                // Motsatt av alt ovenfor
                pauseMenu.SetActive(false);
                Time.timeScale = 1;
                isPaused = false;

            }

        }




    }

    // Public metode for � starte spillet - Resume
    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;

    }

    // Public metode for � avslutte spillet -   Quit
    public void QuitGame()
    {
        Debug.Log("Spillet AVSLUTTER!");
        Application.Quit();
    }

    public void Settings()
    {

    }

}