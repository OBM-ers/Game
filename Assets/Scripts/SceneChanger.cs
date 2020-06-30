using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    //exit to main menu
    public void ExitToMenuObm()
    {
        SceneManager.LoadScene("MenuScene");
    }

    //reloads the current scene
    public void ReloadSceneObm()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }

    //exits to the hub scene
    public void ExitToHubObm()
    {
        SceneManager.LoadScene("HubScene");
    }
}
