using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAlex : Item
{
    [SerializeField]
    private string text;

    public override void OnInteraction()
    {
        Save.WriteSave();
        Menu.TextNPC.ShowTextFor(string.Format("[{0}] : {1}", itemName, text), 5);
    }
}
