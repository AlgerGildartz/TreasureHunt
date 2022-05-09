using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Item
{
    [SerializeField]
    private string text;

    public override void OnInteraction()
    {
        Menu.TextNPC.ShowTextFor(string.Format("[{0}] : {1}", itemName, text), 5);
    }
}
