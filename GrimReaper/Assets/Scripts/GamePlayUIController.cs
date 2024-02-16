using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamePlayUIController : MonoBehaviour
{
    public static GamePlayUIController Instance;

    [SerializeField] GameObject pauseMsg;
    [SerializeField] GameObject saveMsg;
    [SerializeField] Button saveBtn;
    public Slider health;

    [SerializeField] GameObject inventory;
    [SerializeField] GameObject minimap;

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
        minimap.SetActive(false);
        Debug.Log(Application.persistentDataPath + "/MySaveData.txt");
    }

    private void Update()
    {

    }

    public void PauseGame()
    {
        SoundController.instance.Play("Click");
        pauseMsg.SetActive(true);
        Time.timeScale = 0;

    }

//resume game after pause
    public void ResumeGame()
    {
        SoundController.instance.Play("Click");
        pauseMsg.SetActive(false);
        Time.timeScale = 1;
    }

//save game
    public void SaveGame()
    {
        SoundController.instance.Play("Click");
        getDataAndSave();
        saveMsg.SetActive(true);
        saveMsg.SetActive(true);
        saveBtn.interactable = false;
        saveBtn.interactable = true;
        Invoke("CloseSaveMsg", 1);
    }

    public void getDataAndSave()
    {  
        int level = SceneManager.GetActiveScene().buildIndex;
        Transform playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        int life = DataKeeper.Instance.lifeAmount;
        int banana = DataKeeper.Instance.bananaAmount;
        int watermelon = DataKeeper.Instance.watermelonAmount;
        int cherry = DataKeeper.Instance.cherryAmount;
        int enemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
        Debug.Log(banana);
        SaveGameManager.Instance().SaveGame(level, playerTransform, life, banana, watermelon, cherry, enemies);
    }
//close the noti after save game
    public void CloseSaveMsg()
    {
        saveMsg.SetActive(false);
    }

//open&close inventory panel
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

    //open&close minimap panel
    public void Minimap()
    {
        SoundController.instance.Play("Click");
        if (minimap.activeSelf)
        {
            minimap.SetActive(false);
        }
        else
        {
            minimap.SetActive(true);
        }
    }

    public void UpdateHealth(float value)
    {
        health.GetComponent<Slider>().value += value;
    }






}

