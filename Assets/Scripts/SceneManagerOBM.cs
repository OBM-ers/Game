using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerOBM : MonoBehaviour
{
    public GameObject timerObm;
    private bool continueGameObm = false;

    void Update()
    {
        if (continueGameObm == true)
        {
            timerObm.GetComponent<TimerOBM>().RestartTimerObm();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            continueGameObm = false;
        }
    }

    public void ExitToMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void ReloadScene()
    {
        continueGameObm = true;
    }
}
