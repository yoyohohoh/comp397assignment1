using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class OptionsController : MonoBehaviour
{
    [SerializeField] GameObject optionsPanel;
    [SerializeField] GameObject keyOption1On;
    [SerializeField] GameObject keyOption2On;
    [SerializeField] GameObject keyOption1Off;
    [SerializeField] GameObject keyOption2Off;

    public void Start()
    {
        SetKeyToOption1();
    }

    public void OpenOptionsPanel()
    {
        // Close options menu
        optionsPanel.SetActive(true);
    }
    public void CloseOptionsPanel()
    {
        // Close options menu
        optionsPanel.SetActive(false);
    }

    public void SetKeyToOption1()
    {
        keyOption1On.SetActive(true);
        keyOption1Off.SetActive(false);
        keyOption2On.SetActive(false);
        keyOption2Off.SetActive(true);
    }

    public void SetKeyToOption2()
    {
        keyOption1On.SetActive(false);
        keyOption1Off.SetActive(true);
        keyOption2On.SetActive(true);
        keyOption2Off.SetActive(false);
    }

    public void SwitchKey()
    {         
        if (keyOption1On.activeSelf)
        {
            SetKeyToOption2();
        }
        else
        {
            SetKeyToOption1();
        }
    }
}
