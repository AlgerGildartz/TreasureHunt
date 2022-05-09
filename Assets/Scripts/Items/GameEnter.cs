using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnter : Item
{
    public override void OnInteraction()
    {
        Save.WriteSave();
        LoadScene();
    }

    private void LoadScene()
    {
        SceneManager.LoadScene("minigame");
    }
}
