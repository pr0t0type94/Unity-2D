﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void changeScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void exitGame()
    {
        Debug.Log("DENTRO");
        Application.Quit();
    }
}
