using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataKeeper : MonoBehaviour
{
    public static DataKeeper Instance;

    public float musicVolume;
    public float soundVolume;

    private OptionsController optionsController;
    public float musicSlide;
    public float soundSlide;

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
        optionsController = OptionsController.Instance;
        optionsController.musicVolumeLevel = DataKeeper.Instance.musicVolume;
        optionsController.soundVolumeLevel = DataKeeper.Instance.soundVolume;
    }

    public void Update()
    {
        Debug.Log("Music: " + musicVolume + "; Sound: " + soundSlide);
        musicSlide = optionsController.musicVolumeLevel;
        soundSlide = optionsController.soundVolumeLevel;
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
