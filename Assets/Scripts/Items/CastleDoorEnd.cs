using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CastleDoorEnd : Item
{
    public override void OnInteraction()
    {
        MainScript.castleWon = true;
        MainScript.useSave = true;

        SceneManager.LoadScene("TreasureHunt");
    }
}
