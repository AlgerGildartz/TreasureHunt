using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Item
{

    public override void OnInteraction()
    {
        if (CanOpen())
        {
            Destroy(gameObject);
        }
        else
        {
            Menu.TextInfo.ShowTextFor("You don't have all the letters", 2);
        }
    }

    public bool CanOpen()
    {
        return Inventory.GetLetters().Count >= 5;
    }
}
