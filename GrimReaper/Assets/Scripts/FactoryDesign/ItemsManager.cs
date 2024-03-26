using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsManager : MonoBehaviour
{
    [SerializeField] public ItemsFactory _itemsFactory;
    void Start()
    {
        for(int i = 0; i < 10; i++)
        {
            int randomX = Random.Range(126, 280);
            int randomY = Random.Range(22, 52);
            Vector3 position4 = new Vector3(randomX, -randomY, 0f);

            int randomItem = Random.Range(0, 3);
            switch (randomItem)
            {
                case 0:
                    Instantiate(_itemsFactory.CreateItems("Banana").GetItemsPrefab(), position4, Quaternion.identity);
                    break;
                case 1:
                    Instantiate(_itemsFactory.CreateItems("Cherry").GetItemsPrefab(), position4, Quaternion.identity);
                    break;
                case 2:
                    Instantiate(_itemsFactory.CreateItems("Watermelon").GetItemsPrefab(), position4, Quaternion.identity);
                    break;
            }
        }
    }

}
