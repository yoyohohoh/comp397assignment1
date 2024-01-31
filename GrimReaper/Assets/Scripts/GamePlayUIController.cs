using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayUIController : MonoBehaviour
{
    [SerializeField] GameObject pauseMsg;
    [SerializeField] GameObject saveMsg;
    [SerializeField] Button saveBtn;

    [SerializeField] GameObject inventory;


    public void Start()
    {
        pauseMsg.SetActive(false);
        saveMsg.SetActive(false);
        inventory.SetActive(false);
    }

    public void PauseGame()
    {
        pauseMsg.SetActive(true);
    }

    public void ResumeGame()
    {
        pauseMsg.SetActive(false);
    }

    public void SaveGame()
    {
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
