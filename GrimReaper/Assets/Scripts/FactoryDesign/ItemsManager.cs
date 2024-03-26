using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsManager : MonoBehaviour
{
    [SerializeField] public ItemsFactory _itemsFactory;
    void Start()
    {
        //x 126-280 y-52 - -22
        //Vector3 position = new Vector3(280.0f, -22.0f, 0f);
        //Instantiate(_itemsFactory.CreateItems("Banana").GetItemsPrefab(), position, Quaternion.identity);

        //Vector3 position1 = new Vector3(126.0f, -52.0f, 0f);
        //Instantiate(_itemsFactory.CreateItems("Cherry").GetItemsPrefab(), position1, Quaternion.identity);

        //Vector3 position2 = new Vector3(126.0f, -22.0f, 0f);
        //Instantiate(_itemsFactory.CreateItems("Watermelon").GetItemsPrefab(), position2, Quaternion.identity);

        //Vector3 position3 = new Vector3(280.0f, -52.0f, 0f);
        //Instantiate(_itemsFactory.CreateItems("Banana").GetItemsPrefab(), position3, Quaternion.identity);

        for(int i = 0; i < 10; i++)
        {
            int randomX = Random.Range(126, 280);
            //genrate random number from 22 to 52
            int randomY = Random.Range(22, 52);
            Vector3 position4 = new Vector3(randomX, -randomY, 0f);
            Instantiate(_itemsFactory.CreateItems("Banana").GetItemsPrefab(), position4, Quaternion.identity);
        }
    }

}
