using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayUIController : MonoBehaviour
{
    [SerializeField] GameObject pauseMsg;

    public void Start()
    {
        pauseMsg.SetActive(false);
    }

    public void PauseGame()
    {
        pauseMsg.SetActive(true);
    }

    public void ResumeGame()
    {
        pauseMsg.SetActive(false);
    }
}
