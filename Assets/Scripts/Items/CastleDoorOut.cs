using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CastleDoorOut : Item
{

    public override void OnInteraction()
    {
        MainScript.GetPlayer().transform.localPosition = new Vector3(312, 86, 1165);
        Save.WriteSave();

        LoadScene();
    }
    public void LoadScene()
    {
        SceneManager.LoadScene("Castle");
    }
}
