using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

[System.Serializable]
public class Save
{
    public float[] playerPos;
    public float[] playerRot;
    public List<LetterInfo> inv;
    public string word;
    public string mixedWord;

    public static void WriteSave()
    {
        Save s = MainScript.CreateSave();

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/gamesave.save");
        bf.Serialize(file, s);
        file.Close();
    }
}
