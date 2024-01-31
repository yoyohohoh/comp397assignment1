using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataKeeper : MonoBehaviour
{
    public static DataKeeper Instance;
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
}
