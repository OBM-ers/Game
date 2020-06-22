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

    public void ExitToMenuObm()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void ReloadSceneObm()
    {
        continueGameObm = true;
    }

    public void ExitToHubObm()
    {
        SceneManager.LoadScene("HubScene");
    }
}
