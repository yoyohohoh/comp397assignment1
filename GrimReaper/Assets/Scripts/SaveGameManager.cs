using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

[System.Serializable]
class PlayerData
{
    public string level;
    public string position;
    public string life;
    public string inventoryBanana;
    public string inventoryWatermelon;
    public string inventoryCherry;
    public string enemiesLeft;
}

[System.Serializable]
public class SaveGameManager
{
    private static SaveGameManager m_instance = null;
    private SaveGameManager() { }
    public static SaveGameManager Instance()
    {
        return m_instance ??= new SaveGameManager();
    }

    public void SaveGame(int level, Transform playerTransform, int life, int banana, int watermelon, int cherry, int enemies)
    {
        var binaryFormatter = new BinaryFormatter();
        var file = File.Create(Application.persistentDataPath + "/MySaveData.txt");

        var data = new PlayerData
        {
            level = level.ToString(),
            position = playerTransform.position.ToString(),
            life = life.ToString(),
            inventoryBanana = banana.ToString(),
            inventoryWatermelon = watermelon.ToString(),
            inventoryCherry = cherry.ToString(),
            enemiesLeft = enemies.ToString()
        };
        binaryFormatter.Serialize(file, data);
        file.Close();
        Debug.Log("Game Data Save");
    }

}