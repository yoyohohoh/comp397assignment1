using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayUIController : MonoBehaviour
{
    public static GamePlayUIController Instance;


    [SerializeField] GameObject pauseMsg;
    [SerializeField] GameObject saveMsg;
    [SerializeField] Button saveBtn;
    public Slider health;

    [SerializeField] GameObject inventory;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

    }

    public void Start()
    {
        pauseMsg.SetActive(false);
        saveMsg.SetActive(false);
        inventory.SetActive(false);
    }

    public void PauseGame()
    {
        SoundController.instance.Play("Click");
        pauseMsg.SetActive(true);
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPaused = true;
#endif
    }

    public void ResumeGame()
    {
        SoundController.instance.Play("Click");
        pauseMsg.SetActive(false);
    }

    public void SaveGame()
    {
        SoundController.instance.Play("Click");
        saveMsg.SetActive(true);
        saveMsg.SetActive(true);
        saveBtn.interactable = false;
        saveBtn.interactable = true;
        Invoke("CloseSaveMsg", 1);
    }

    public void CloseSaveMsg()
    {
        saveMsg.SetActive(false);
    }

    public void Inventory()
    {
        SoundController.instance.Play("Click");
        if (inventory.activeSelf)
        {
            inventory.SetActive(false);
        }
        else
        {
            inventory.SetActive(true);
        }
    }




}

