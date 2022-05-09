using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGame : MonoBehaviour
{

    [SerializeField]
    private string sceneName;

    public void NewGame()
    {
        LoadScene();
    }

    public void LoadGame() {
        MainScript.useSave = true;
        LoadScene();
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
