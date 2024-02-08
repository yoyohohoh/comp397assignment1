using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class InventoryController : MonoBehaviour
{
    [SerializeField] public Image banana;
    [SerializeField] public int bananaCount;
    [SerializeField] public Text bananaText;
    [SerializeField] public Image watermelon;
    [SerializeField] public int watermelonCount;
    [SerializeField] public Text watermelonText;
    [SerializeField] public Image cherry;
    [SerializeField] public int cherryCount;
    [SerializeField] public Text cherryText;
    void Update()
    {
        colorItem(bananaCount, banana);
        countItem(bananaCount, bananaText);
        colorItem(watermelonCount, watermelon);
        countItem(watermelonCount, watermelonText);
        colorItem(cherryCount, cherry);
        countItem(cherryCount, cherryText);
    }

    void colorItem(int count, Image item)
    {
//"activate" when player acquire at least 1 item
        if (count == 0)
        {
            item.GetComponent<Image>().color = new Color(0, 0, 0, 255);
        }
        else
        {
            item.GetComponent<Image>().color = new Color(255, 255, 255, 255);
        }
    }

    void countItem(int count, Text text)
    {
//showing the count of the item on UI text
        text.text = count.ToString();
        if (count == 0)
        {
            text.enabled = false;
        }
        else if (count > 0)
        {
            text.enabled = true;
        }

    }
}
