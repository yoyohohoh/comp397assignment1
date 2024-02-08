using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataKeeper : MonoBehaviour
{
    public static DataKeeper Instance;
    [Header("Menu")]
    public float musicVolume;
    public float soundVolume;
    public bool isOgKey;

    private OptionsController optionsController;
    private float musicSlide;
    private float soundSlide;

    [Header("Inventory")]
    public int bananaAmount;
    public int watermelonAmount;
    public int cherryAmount;
    private InventoryController inventoryController;

    [Header("Life")]
    public int lifeAmount;
    private LifeController lifeController;

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

        inventoryController = InventoryController.Instance;
        inventoryController.bananaCount = DataKeeper.Instance.bananaAmount;
        inventoryController.watermelonCount = DataKeeper.Instance.watermelonAmount;
        inventoryController.cherryCount = DataKeeper.Instance.cherryAmount;

        lifeController = LifeController.Instance;
        //lifeController.life = DataKeeper.Instance.lifeAmount;
    }

    public void Update()
    {
        //menu
        //bgm
        musicSlide = optionsController.musicVolumeLevel;
        //soundeffect
        soundSlide = optionsController.soundVolumeLevel;
        //key mapping
        isOgKey = optionsController.isOgKey;
        
        SetMusicVolume(musicSlide);
        SetSoundVolume(soundSlide);

        //inventory
        bananaAmount = inventoryController.bananaCount;
        watermelonAmount = inventoryController.watermelonCount;
        cherryAmount = inventoryController.cherryCount;

        //life
        lifeAmount = lifeController.life;
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
