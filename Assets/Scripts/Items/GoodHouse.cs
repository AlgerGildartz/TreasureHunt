using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodHouse : House
{
    [SerializeField]
    private GameObject lettersContainer;
    [SerializeField]
    private GameObject alex;

    public override void OnInteraction()
    {
        Menu.TextNPC.ShowTextFor("[Alex] : Oh thank you, I can sleep in the warm now. Earlier, I found this in the forest, maybe it can interest you.", 5);
        lettersContainer.transform.GetChild(2).localPosition = new Vector3(31.61f, 22.048f, 64.88f);

        alex.transform.localPosition = new Vector3(-87.92f, 27.39f, -60.71f);
        alex.transform.eulerAngles = new Vector3(0, 70, 0);

        alex.layer = 0;
    }
}
