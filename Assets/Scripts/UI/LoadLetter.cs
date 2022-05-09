using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadLetter : MonoBehaviour
{

    public Letter letter;
    public GameObject letterShow;

    public void ShowLetter()
    {
        Text[] childs = letterShow.GetComponentsInChildren<Text>();
        childs[0].text = letter.GetName();
        childs[1].text = letter.GetText().Replace("\\n", "\n");
        childs[2].text = letter.GetLetter().ToString();
    }
}
