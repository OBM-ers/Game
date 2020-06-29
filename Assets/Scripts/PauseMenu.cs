using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    //variables
    public static bool gameIsPausedObm = false;
    public GameObject pauseMenuUiObm;
    public GameObject optionMenuUiObm;
    
    void Update()
    {
        //checks if the escape button is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //checks if game is paused
            if (gameIsPausedObm)
            {
                //Resumes game and if option menu is open, it will close
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

    //Resume game
    public void ResumeObm()
    {
        pauseMenuUiObm.SetActive(false);
        Time.timeScale = 1f;
        gameIsPausedObm = false;
    }

    //Pause game
    public void PauseObm()
    {
        pauseMenuUiObm.SetActive(true);
        Time.timeScale = 0.0001f;
        gameIsPausedObm = true;
    }
}
