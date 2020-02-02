using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.Escape))
        {

            if(GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }

        }

    }

    public void Resume() // Resume Function
    {

        pauseMenuUI.SetActive(false); // Set the pause menu to false
        Time.timeScale = 1f; // Unfreeze the background
        GameIsPaused = false; // Game is not paused


    }

    void Pause() // Pause Function
    {

        pauseMenuUI.SetActive(true); // Set the pause menu to true
        Time.timeScale = 0f; // Freeze the background
        GameIsPaused = true; // Game is now paused

        Cursor.visible = true;

        Cursor.lockState = CursorLockMode.None;
    }

    public void LoadMenu()
    {

        Time.timeScale = 1f;
        SceneManager.LoadScene("GGJ20_StartMenu");

    }

    public void QuitGame()
    {

        Debug.Log("Quitting");
        Application.Quit();
        
    }
}
