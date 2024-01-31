using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataKeeper : MonoBehaviour
{
    public static DataKeeper Instance;

    public float musicVolume;
    public float soundVolume;

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

    public void Update()
    {
        DataKeeper.Instance.musicVolume = musicOption.GetComponent<Slider>().value;
        DataKeeper.Instance.soundVolume = soundOption.GetComponent<Slider>().value;
    }
}
