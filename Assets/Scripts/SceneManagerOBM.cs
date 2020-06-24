﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerOBM : MonoBehaviour
{
    public void ExitToMenuObm()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void ReloadSceneObm()
    {
        //SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }

    public void ExitToHubObm()
    {
        SceneManager.LoadScene("HubScene");
    }
}
