﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndCredit : MonoBehaviour
{
    public void LoadNewScene()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
