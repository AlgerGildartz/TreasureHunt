using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Letter : Item
{
    [SerializeField]
    private string text;

    [SerializeField]
    private int id;

    private char letter;



    public override void OnInteraction()
    {
        letter = MainScript.GetMixed()[id - 1];
        Inventory.AddLetter(this);
        Menu.TextInfo.ShowTextFor("Press tab to see the letter", 2);
        gameObject.SetActive(false);
    }

    public string GetText()
    {
        return text;
    }

    public char GetLetter()
    {
        return letter;
    }

    public int GetID()
    {
        return id;
    }

    /// <summary>
    /// Gather all informations to a serializable class
    /// </summary>
    /// <returns></returns>
    public LetterInfo RegroupInfos()
    {
        LetterInfo li = new LetterInfo();
        li.id = id;
        li.text = text;
        li.letter = letter;
        return li;
    }

    /// <summary>
    /// Set informations for the serailized class
    /// </summary>
    /// <param name="infos"></param>
    public void SetInfos(LetterInfo infos)
    {
        id = infos.id;
        text = infos.text;
        letter = infos.letter;
    }
}
