using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPausedObm = false;

    public GameObject pauseMenuUiObm;
    public GameObject optionMenuUiObm;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPausedObm)
            {
                if (!optionMenuUiObm.activeSelf)
                {
                    ResumeObm();
                }
                else
                {
                    pauseMenuUiObm.SetActive(true);
                    optionMenuUiObm.SetActive(false);
                }
            }
            else
            {
                PauseObm();
            }
        }
    }

    public void ResumeObm()
    {
        pauseMenuUiObm.SetActive(false);
        Time.timeScale = 1f;
        gameIsPausedObm = false;
    }

    public void PauseObm()
    {
        pauseMenuUiObm.SetActive(true);
        Time.timeScale = 0f;
        gameIsPausedObm = true;
    }
}
