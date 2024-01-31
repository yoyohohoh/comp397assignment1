using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] GameObject menu;
    [SerializeField] GameObject options;

    public void Start()
    {
        //if the scene index is 0, then the main menu is active
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            menu.SetActive(false);
            options.SetActive(false);
        }
        else
        {
            //menu.SetActive(true);
            options.SetActive(true);
        }
        
    }
    public void OpenMenu()
    {
        // Open menu
        menu.SetActive(true);
    }

    public void CloseMenu()
    {
        // Close menu
        menu.SetActive(false);
    }

    public void NewGame()
    {
        // New game
        SceneManager.LoadScene(1);
    }

    public void LoadGame()
    {
        // Load game
    }

    public void OpenOptions()
    {
        // Open options menu
        options.SetActive(true);
    }

    public void CloseOptions()
    {
        // Close options menu
        options.SetActive(false);
    }

    public void ExitGame()
    {
        // Exit
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
