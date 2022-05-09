using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Rift : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        MainScript.useSave = true;
        SceneManager.LoadScene("TreasureHunt");
    }
}
