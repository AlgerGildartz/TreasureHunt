using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Safe : Item
{
    public override void OnInteraction()
    {
        Menu.SafeMenu.ShowMenu(true);
    }
}
