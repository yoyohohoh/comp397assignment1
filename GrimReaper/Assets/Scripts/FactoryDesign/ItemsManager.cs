using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsManager : MonoBehaviour
{
    [SerializeField] public ItemsFactory _itemsFactory;
    void Start()
    {
        Vector3 position = new Vector3(126.0f, -52.0f, 0f);
        Instantiate(_itemsFactory.CreateItems("Banana").GetItemsPrefab(), position, Quaternion.identity);

        Vector3 position1 = new Vector3(130.0f, -52.0f, 0f);
        Instantiate(_itemsFactory.CreateItems("Cherry").GetItemsPrefab(), position1, Quaternion.identity);

        Vector3 position2 = new Vector3(134.0f, -52.0f, 0f);
        Instantiate(_itemsFactory.CreateItems("Watermelon").GetItemsPrefab(), position2, Quaternion.identity);
    }

}
