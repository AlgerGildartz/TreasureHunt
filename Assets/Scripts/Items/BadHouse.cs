using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BadHouse : House
{
    public override void OnInteraction()
    {
        if (nbError < 2)
        {
            nbError += 1;
            Menu.TextInfo.ShowTextFor("This is not the good house", 2);
        } else
        {
            Menu.TextInfo.ShowTextFor("You lost", 2);
            MainScript.useSave = true;
            nbError = 0;
            StartCoroutine(LoadSceneAfter(2));
        }
    }

    private IEnumerator LoadSceneAfter(float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene("TreasureHunt");
    }
}
