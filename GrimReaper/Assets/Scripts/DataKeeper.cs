using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataKeeper : MonoBehaviour
{
    public static DataKeeper Instance;

    public float musicVolume;
    public float soundVolume;
    public bool isOgKey;

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
        optionsController = OptionsController.Instance;
        optionsController.musicVolumeLevel = DataKeeper.Instance.musicVolume;
        optionsController.soundVolumeLevel = DataKeeper.Instance.soundVolume;
        optionsController.isOgKey = DataKeeper.Instance.isOgKey;
    }

    public void Update()
    {
        //bgm
        musicSlide = optionsController.musicVolumeLevel;
        //soundeffect
        soundSlide = optionsController.soundVolumeLevel;
        //key mapping
        isOgKey = optionsController.isOgKey;
        
        SetMusicVolume(musicSlide);
        SetSoundVolume(soundSlide);

    }

    // store for music&sound volume from previous scene
    public void SetMusicVolume(float volume)
    {
        DataKeeper.Instance.musicVolume = volume;
    }
    public void SetSoundVolume(float volume)
    {
        DataKeeper.Instance.soundVolume = volume;
    }


}
