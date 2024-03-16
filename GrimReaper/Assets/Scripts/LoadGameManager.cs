using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadGameManager : MonoBehaviour
{
    public static LoadGameManager _instance;
    public static LoadGameManager Instance
    {
        get
        {
            return _instance;
        }
    }
    [SerializeField] GameObject panel;
    [SerializeField] Button save1;
    [SerializeField] Button save2;
    [SerializeField] Button save3;

    private int saveCount;
    public int saveSlot;
    private string timeStamp;

    private void Awake()
    {
        _instance = this;
    }

    void Start()
    {
        panel.SetActive(false);
        saveCount = 0;
        save1.interactable = false;
        save2.interactable = false;
        save3.interactable = false;
    }

    private void Update()
    {
        saveSlot = saveCount % 3 + 1;
        timeStamp = System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
    }

    public void ClosePanel()
    {
        panel.SetActive(false);
    }

    public void UpdateButton()
    {
        panel.SetActive(true);
        switch (saveSlot)
        {
            case 1:
                save1.interactable = true;
                save1.GetComponentInChildren<Text>().text = timeStamp;
                GamePlayUIController.Instance.getDataAndSave();
                break;
            case 2:
                save2.interactable = true;
                save2.GetComponentInChildren<Text>().text = timeStamp;
                GamePlayUIController.Instance.getDataAndSave();
                break;
            case 3:
                save3.interactable = true;
                save3.GetComponentInChildren<Text>().text = timeStamp;
                GamePlayUIController.Instance.getDataAndSave();
                break;
        }
        saveCount++;
    }
}
