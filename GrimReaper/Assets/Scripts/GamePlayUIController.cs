using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayUIController : MonoBehaviour
{
    [SerializeField] GameObject pauseMsg;
    [SerializeField] GameObject saveMsg;
    [SerializeField] Button saveBtn;


    public void Start()
    {
        pauseMsg.SetActive(false);
        saveMsg.SetActive(false);
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
        //saveBtn button color change to normal
        saveBtn.interactable = false;
        saveBtn.interactable = true;
        Invoke("CloseSaveMsg", 1);
    }

    public void CloseSaveMsg()
    {
        saveMsg.SetActive(false);
    }


}
