using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    [SerializeField]
    protected string itemName;

    public string GetName()
    {
        return itemName;
    }

    public abstract void OnInteraction();
}
