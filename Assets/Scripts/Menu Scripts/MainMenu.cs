using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //Load hubscene
    public void GameHubObm()
    {
        SceneManager.LoadScene("HubScene");
    }

    //Quit game
    public void QuitGameObm()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
