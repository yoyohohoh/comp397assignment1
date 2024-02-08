using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LifeController : MonoBehaviour
{
    public static LifeController _instance;
    public static LifeController Instance
    {
        get
        {
            return _instance;
        }
    }
    private DataKeeper dataKeeper;
    [SerializeField] public int life;
    [SerializeField] public Image life1;
    [SerializeField] public Image life2;
    [SerializeField] public Image life3;
    private int checkLife;
    private int dataLife;
    private void Awake()
    {
        _instance = this;
    }


    void Start()
    {
        dataKeeper = DataKeeper.Instance;
        checkLife = GameObject.FindGameObjectsWithTag("Life").Length;
        dataLife = dataKeeper.lifeAmount;
        if(checkLife > dataLife)
        {
            life = checkLife;
        }
        else
        {
            life = dataKeeper.lifeAmount;
        }

    }

    // Update is called once per frame
    void Update()
    {
        switch(life)
        {
            case 3:
                life1.enabled = true;
                life2.enabled = true;
                life3.enabled = true;
                break;
            case 2:
                life1.enabled = true;
                life2.enabled = true;
                life3.enabled = false;
                break;
            case 1:
                life1.enabled = true;
                life2.enabled = false;
                life3.enabled = false;
                break;

        }
    }
}
