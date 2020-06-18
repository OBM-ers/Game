using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerOBM : MonoBehaviour
{
    public void ExitToMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene("SnowScene");
    }
}
