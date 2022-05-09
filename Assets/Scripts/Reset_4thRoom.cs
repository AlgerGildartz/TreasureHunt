using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset_4thRoom : Item
{
    [SerializeField]
    private GameObject red;
    [SerializeField]
    private GameObject blue;

    private Vector3 posRed = new Vector3(49753.23f, -82.549f, -1162.93f);
    private Vector3 posBlue = new Vector3(49756.23f, -82.549f, -1168.93f);

    public override void OnInteraction()
    {
        red.transform.localPosition = posRed;
        blue.transform.localPosition = posBlue;
    }
}
