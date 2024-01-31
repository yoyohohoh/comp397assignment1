using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataKeeper : MonoBehaviour
{
    public static DataKeeper Instance;

    public float musicVolume;
    public float soundVolume;
    public bool isRevisit;

    private OptionsController optionsController;
    private float musicSlide;
    private float soundSlide;


    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

    }
    public void Start()
    {

    }

    public void FixedUpdate()
    {
        Debug.Log("Is Revisit: " + isRevisit);
        Debug.Log("Music: " + musicVolume + "; Sound: " + soundSlide);
        optionsController = OptionsController.Instance;
        optionsController.musicVolumeLevel = DataKeeper.Instance.musicVolume;
        optionsController.soundVolumeLevel = DataKeeper.Instance.soundVolume;
        optionsController.isRevisit = DataKeeper.Instance.isRevisit;
    }

    public void Update()
    {

        musicSlide = optionsController.musicVolumeLevel;
        soundSlide = optionsController.soundVolumeLevel;
        if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex != 0)
        {
            isRevisit = true;
        }
        
        SetMusicVolume(musicSlide);
        SetSoundVolume(soundSlide);

    }

    public void SetMusicVolume(float volume)
    {
        DataKeeper.Instance.musicVolume = volume;
    }
    public void SetSoundVolume(float volume)
    {
        DataKeeper.Instance.soundVolume = volume;
    }

}
