using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zones : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        other.GetComponent<PlayerControl>().walkSpeed = 5;

    }

    public void OnTriggerExit(Collider other)
    {
        other.GetComponent<PlayerControl>().walkSpeed = 10;

    }
}
