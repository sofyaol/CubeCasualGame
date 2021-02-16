using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;

public static class SaveGame
{
    public static void Save(long maxScore)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath
          + "/SaveData.dat");

        SaveData data = new SaveData();
        data.MaxScore = maxScore;

        bf.Serialize(file, data);
        file.Close();
    }

    public static long Load()
    {
        if (File.Exists(Application.persistentDataPath
    + "/SaveData.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file =
              File.Open(Application.persistentDataPath
              + "/SaveData.dat", FileMode.Open);
            SaveData data = (SaveData)bf.Deserialize(file);
            file.Close();
            long maxScore = data.MaxScore;

            return maxScore;

        }

        else return 0;
    }
}
