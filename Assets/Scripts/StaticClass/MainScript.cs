using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class MainScript : MonoBehaviour
{
    [SerializeField]
    private GameObject labyrinth = null;
    [SerializeField]
    private GameObject wall = null;
    [SerializeField]
    private GameObject lettersContainer;

    [SerializeField]
    private GameObject playerContainer;

    private static MainScript instance = null;

    private static string word = "Chest".ToUpper();
    private static string mixedWord = "";

    public static bool useSave = false;
    // A utiliser apres les victoire des jeux
    public static bool minigameWon = false;
    public static bool castleWon = false;

    // Start is called before the first frame update
    void Start()
    {
        SetInstance(this);
        CreateLabyrinth.Create(wall, labyrinth);
        MixWord();
        if (useSave)
        {
            LoadGame();
            useSave = false;
            if (minigameWon)
            {
                lettersContainer.transform.GetChild(4).localPosition = new Vector3(720, 88, 803);
                lettersContainer.transform.GetChild(4).eulerAngles = new Vector3(0, -124, 0);
            }
            if (castleWon)
            {
                lettersContainer.transform.GetChild(3).localPosition = new Vector3(315, 87.5f, 1175.85f);
            }

        }
        else
        {
            Inventory.CleanLetters();
            Save.WriteSave();
        }
            
    } 

    private static void SetInstance(MainScript myInstance)
    {
        instance = myInstance;
    }

    public static string GetWord()
    {
        return word;
    }

    public static string GetMixed()
    {
        return mixedWord;
    }

    public void MixWord()
    {
        List<int> numbers = new List<int>();
        int r = 0;
        for (int i = 0; i < word.Length; i++)
        {
            numbers.Add(i);
        }
        for (int i = 0; i < word.Length; i++)
        {
            r = Random.Range(0, numbers.Count);
            mixedWord += word[numbers[r]];
            numbers.RemoveAt(r);
        }
    }

    public static Save CreateSave()
    {
        Save s = new Save();
        s.inv = LettersToInfo(Inventory.GetLetters());
        s.word = word;
        s.mixedWord = mixedWord;
        s.playerPos = VectorToArray(instance.playerContainer.transform.GetChild(0).position);
        s.playerRot = VectorToArray(instance.playerContainer.transform.GetChild(0).eulerAngles);

        return s;
    }

    public void LoadGame()
    {
        if (File.Exists(Application.persistentDataPath + "/gamesave.save"))
        {
            // Load file
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/gamesave.save", FileMode.Open);
            Save save = (Save)bf.Deserialize(file);
            file.Close();

            // Load game
            Inventory.CleanLetters();
            foreach (LetterInfo info in save.inv)
            {
                lettersContainer.transform.GetChild(info.id - 1).GetComponent<Letter>().SetInfos(info);
                Inventory.AddLetter(lettersContainer.transform.GetChild(info.id - 1).GetComponent<Letter>());
                lettersContainer.transform.GetChild(info.id - 1).gameObject.SetActive(false);
            }
            playerContainer.transform.GetChild(0).position = ArrayToVector(save.playerPos);
            playerContainer.transform.GetChild(1).position = ArrayToVector(save.playerPos) + new Vector3(0, 0.75f, 0);

            playerContainer.transform.GetChild(1).GetComponent<CamControl>().ChangeRotation(ArrayToVector(save.playerRot));
            word = save.word;
            mixedWord = save.mixedWord;
        }
    }

    public static GameObject GetPlayer()
    {
        return instance.playerContainer.transform.GetChild(0).gameObject;
    }

    private static float[] VectorToArray(Vector3 v)
    {
        float[] arr = new float[3];
        arr[0] = v.x;
        arr[1] = v.y;
        arr[2] = v.z;
        return arr;
    }

    private static Vector3 ArrayToVector(float[] arr)
    {
        Vector3 v = new Vector3(arr[0], arr[1], arr[2]);

        return v;
    }

    private static List<LetterInfo> LettersToInfo(List<Letter> letters)
    {
        List<LetterInfo> infos = new List<LetterInfo>();
        foreach (Letter l in letters)
        {
            infos.Add(l.RegroupInfos());
        }
        return infos;
    }
}
