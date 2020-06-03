using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gobMainMenuOBM : MonoBehaviour
{
    public void GameHubOBM ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGameOBM ()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
