using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset_5thRoom : Item
{
    [SerializeField]
    private GameObject red;
    [SerializeField]
    private GameObject blue;
    [SerializeField]
    private GameObject green;

    private Vector3 posRed = new Vector3(49765.23f, -82.55f, -1145.93f);
    private Vector3 posBlue = new Vector3(49738.23f, -82.55f, -1124.93f);
    private Vector3 posGreen = new Vector3(49741.2f, -82.55f, -1142.93f);

    public override void OnInteraction()
    {
        red.transform.localPosition = posRed;
        blue.transform.localPosition = posBlue;
        green.transform.localPosition = posGreen;
    }
}
