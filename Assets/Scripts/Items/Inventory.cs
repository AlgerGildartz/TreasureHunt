using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : Object
{

    private static int nbLetters = 5;

    private static List<Letter> letters = new List<Letter>();
    // Start is called before the first frame update

    public static void AddLetter(Letter l)
    {
        letters.Add(l);
    }

    public static List<Letter> GetLetters()
    {
        return letters;
    }

    public static bool[] GetProgression()
    {
        bool[] prog = new bool[5];
        foreach (Letter l in letters)
        {
            prog[l.GetID() - 1] = true;
        }

        return prog;
    }

    public static void CleanLetters()
    {
        letters.RemoveAll(x => true);
    }
}
