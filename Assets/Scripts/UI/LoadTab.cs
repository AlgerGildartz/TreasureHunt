using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadTab : MonoBehaviour
{
    public GameObject prefabBtn;

    [SerializeField]
    private GameObject LettersPanel;
    [SerializeField]
    private GameObject LetterPanel;

    public void LoadLetters()
    {
        GameObject btn;
        RectTransform rt;
        for (int i = 0; i < Inventory.GetLetters().Count; i++)
        {
            btn = Instantiate(prefabBtn);
            btn.transform.SetParent(LettersPanel.transform);
            rt = btn.GetComponent<RectTransform>();
            rt.offsetMax = new Vector2(0, -i * GetComponent<RectTransform>().rect.height / 5);
            rt.offsetMin = new Vector2(0, -(i + 1) * GetComponent<RectTransform>().rect.height / 5);
            // Par rapport à la position donc si on veut une taille de 100 à la position -100 faut mettre -200 au min

            btn.transform.GetChild(0).GetComponent<Text>().text = Inventory.GetLetters()[i].GetName();
            btn.GetComponent<LoadLetter>().letter = Inventory.GetLetters()[i];
            btn.GetComponent<LoadLetter>().letterShow = LetterPanel;
        }
    }

    public void DeleteLetters()
    {
        for (int i = 0; i < LettersPanel.transform.childCount; i++)
        {
            Destroy(LettersPanel.transform.GetChild(0).gameObject);
        }
        ResetLetterPanel();
    }

    void ResetLetterPanel()
    {
        Text[] childs = LetterPanel.GetComponentsInChildren<Text>();
        childs[0].text = "";
        childs[1].text = "";
        childs[2].text = "";
    }
}
