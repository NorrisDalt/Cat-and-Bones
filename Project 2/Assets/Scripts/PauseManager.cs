using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseMenuUI; // Reference to the pause menu UI panel
    private bool isPaused = false;

    private void Awake()
    {
        // Make this object persist across scene loads
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        // Check if the player presses the pause button (e.g., Escape key)
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    // Pauses the game and shows the menu
    public void PauseGame()
    {
        pauseMenuUI.SetActive(true);  // Show the pause menu
        Time.timeScale = 0f;  // Pause the game (freeze time)
        isPaused = true;
    }

    // Resumes the game and hides the menu
    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false);  // Hide the pause menu
        Time.timeScale = 1f;  // Resume the game (normal time flow)
        isPaused = false;
    }

    // Quit the game and return to the main menu
    public void QuitGame()
    {
        SceneManager.LoadScene("MainMenu");  // Replace with your main menu scene name
        Time.timeScale = 1f; // Ensure time resumes when leaving the game
    }
}
