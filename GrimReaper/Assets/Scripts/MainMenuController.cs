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

        if (SceneManager.GetActiveScene().name == "GameOver" || SceneManager.GetActiveScene().name == "GameWin")
        {
            options.SetActive(true);
        }
        else
        {
            menu.SetActive(false);
            options.SetActive(false);
        }

    }

    public void OpenMenu()
    {
        SoundController.instance.Play("Click");
        menu.SetActive(true);
    }

    public void CloseMenu()
    {
        SoundController.instance.Play("Click");
        menu.SetActive(false);
    }

    public void NewGame()
    {
        SoundController.instance.Play("Click");
        SceneManager.LoadScene(1);
    }

    public void LoadGame()
    {
        // Load game
        SoundController.instance.Play("Click");
    }

    public void OpenOptions()
    {
        SoundController.instance.Play("Click");
        options.SetActive(true);
    }

    public void CloseOptions()
    {
        SoundController.instance.Play("Click");
        options.SetActive(false);
    }

    public void ExitGame()
    {
        SoundController.instance.Play("Click");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
