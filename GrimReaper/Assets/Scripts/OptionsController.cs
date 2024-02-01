using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;
using UnityEngine.UI;
using Unity.VisualScripting;

public class OptionsController : MonoBehaviour
{
    public static OptionsController _instance;
    public static OptionsController Instance
    {
        get
        {
            return _instance;
        }
    }

    private DataKeeper dataKeeper;

    [SerializeField] GameObject optionsPanel;
    [SerializeField] GameObject keyOption1On;
    [SerializeField] GameObject keyOption2On;
    [SerializeField] GameObject keyOption1Off;
    [SerializeField] GameObject keyOption2Off;
    [SerializeField] GameObject musicSlide;
    [SerializeField] GameObject soundSlide;
    public float musicVolumeLevel;
    public float soundVolumeLevel;
    public bool isRevisit;
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
            

        }


    }

    public void Start()
    {
        SetKeyToOption1();
        dataKeeper = DataKeeper.Instance;
        isRevisit = dataKeeper.isRevisit;
        
        if (!isRevisit && UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex == 0)
        {
            musicSlide.GetComponent<Slider>().value = 1.0f;
            isRevisit = true;
        }
        else
        {
            musicSlide.GetComponent<Slider>().value = dataKeeper.musicVolume;
        }
        //musicSlide.GetComponent<Slider>().value = dataKeeper.musicVolume;
        soundSlide.GetComponent<Slider>().value = dataKeeper.soundVolume;
    }

    public void Update()
    {

        musicVolumeLevel = musicSlide.GetComponent<Slider>().value;
        soundVolumeLevel = soundSlide.GetComponent<Slider>().value;
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
