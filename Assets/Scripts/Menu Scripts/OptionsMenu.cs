using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{
    //Variables
    public AudioMixer audioMixerObm;

    public Slider masterVolumeSliderObm;

    public Slider sfxVolumeSliderObm;

    public Slider musicVolumeSliderObm;

    public Dropdown qualityDropdownObm;

    public Dropdown gameResolutionDropdownObm;

    public Toggle fullScreenToggleObm;

    public Toggle gameControllerToggleObm;

    private int screenIntObm;

    private int controllerIntObm;

    Resolution[] screenResolutionsObm;

    private bool isFullScreenObm = false;

    private bool useControllerObm = false;

    const string qualityNameObm = "qualityValueObm";
    const string resNameObm = "resolutionOptionObm";

    void Awake()
    {
        //Checks if fullscreen has been toggled before opening the game
        screenIntObm = PlayerPrefs.GetInt("toggleStateFullScreenObm");

        if(screenIntObm == 1)
        {
            isFullScreenObm = true;
            fullScreenToggleObm.isOn = true;
        }
        else
        {
            isFullScreenObm = false;
            fullScreenToggleObm.isOn = false;
        }

        //Checks if controller has been toggled before opening the game
        controllerIntObm = PlayerPrefs.GetInt("toggleStateControllerObm");

        if (screenIntObm == 1)
        {
            useControllerObm = true;
            gameControllerToggleObm.isOn = true;
        }
        else
        {
            useControllerObm = false;
            gameControllerToggleObm.isOn = false;
        }

        //If the game resolution dropdown changes, it will change the resolution
        gameResolutionDropdownObm.onValueChanged.AddListener(new UnityAction<int>(index =>
        {
            PlayerPrefs.SetInt(resNameObm, gameResolutionDropdownObm.value);
            PlayerPrefs.Save();
        }));
        //If the game quality value changes, it will decrease or increase the quality
        qualityDropdownObm.onValueChanged.AddListener(new UnityAction<int>(index =>
        {
            PlayerPrefs.SetInt(qualityNameObm, qualityDropdownObm.value);
            PlayerPrefs.Save();
        }));
    }

    void Start ()
    {
        //Volume values (master). Gets the value from the saved preference
        masterVolumeSliderObm.value = PlayerPrefs.GetFloat("masterVolumeObm", 1f);
        //if the value is changed, it will save the preferences
        audioMixerObm.SetFloat("MasterVolumeObm", PlayerPrefs.GetFloat("masterVolumeObm"));

        sfxVolumeSliderObm.value = PlayerPrefs.GetFloat("sfxVolumeObm", 1f);
        audioMixerObm.SetFloat("SFXVolumeObm", PlayerPrefs.GetFloat("sfxVolumeObm"));

        musicVolumeSliderObm.value = PlayerPrefs.GetFloat("musicVolumeObm", 1f);
        audioMixerObm.SetFloat("MusicVolumeObm", PlayerPrefs.GetFloat("musicVolumeObm"));

        //saves the new quality value
        qualityDropdownObm.value = PlayerPrefs.GetInt(qualityNameObm, 3);

        //Fills the resolution dropdown, loads which resolation the monitor can handle
        screenResolutionsObm = Screen.resolutions;

        gameResolutionDropdownObm.ClearOptions();

        List<string> resolutionOptionsObm = new List<string>();

        int currentGameResolutionIndex = 0;
        for (int i = 0; i < screenResolutionsObm.Length; i++)
        {
            string resolutionOptionObm = screenResolutionsObm[i].width + " x " + screenResolutionsObm[i].height + " " + screenResolutionsObm[i].refreshRate + "Hz";
            resolutionOptionsObm.Add(resolutionOptionObm);

            if (screenResolutionsObm[i].width == Screen.currentResolution.width &&
                screenResolutionsObm[i].height == Screen.currentResolution.height &&
                screenResolutionsObm[i].refreshRate == Screen.currentResolution.refreshRate)
            {
                currentGameResolutionIndex = i;
            }
        }

        gameResolutionDropdownObm.AddOptions(resolutionOptionsObm);
        gameResolutionDropdownObm.value = PlayerPrefs.GetInt(resNameObm, currentGameResolutionIndex);
        gameResolutionDropdownObm.RefreshShownValue();
    }

    //The methods below are the functions attached to the unity game object (event triggers)
    public void SetMasterVolumeObm (float gameMasterVolumeObm)
    {
        PlayerPrefs.SetFloat("masterVolumeObm", gameMasterVolumeObm);
        audioMixerObm.SetFloat("MasterVolumeObm", PlayerPrefs.GetFloat("masterVolumeObm"));
    }

    public void SetSFXVolumeObm(float gameSFXVolumeObm)
    {
        PlayerPrefs.SetFloat("sfxVolumeObm", gameSFXVolumeObm);
        audioMixerObm.SetFloat("SFXVolumeObm", PlayerPrefs.GetFloat("sfxVolumeObm"));
    }

    public void SetMusicVolumeObm(float gameMusicVolumeObm)
    {
        PlayerPrefs.SetFloat("musicVolumeObm", gameMusicVolumeObm);
        audioMixerObm.SetFloat("MusicVolumeObm", PlayerPrefs.GetFloat("musicVolumeObm"));
    }

    public void SetQualityObm (int gameQualityIndexObm)
    {
        QualitySettings.SetQualityLevel(gameQualityIndexObm);
    }

    public void SetGameFullscreenObm (bool gameIsFullscreenObm)
    {
        Screen.fullScreen = gameIsFullscreenObm;

        if (gameIsFullscreenObm == false)
        {
            isFullScreenObm = false;
            PlayerPrefs.SetInt("toggleStateFullScreenObm", 0);
        }
        else
        {
            isFullScreenObm = true;
            PlayerPrefs.SetInt("toggleStateFullScreenObm", 1);
        }
    }

    public void SetControllerObm(bool gameControllerObm)
    {

        if (gameControllerObm == false)
        {
            useControllerObm = false;
            PlayerPrefs.SetInt("toggleStateControllerObm", 0);
        }
        else
        {
            useControllerObm = true;
            PlayerPrefs.SetInt("toggleStateControllerObm", 1);
        }
    }

    public void SetGameResolutionObm (int gameResolutionIndexObm)
    {
        Resolution screenResolutionObm = screenResolutionsObm[gameResolutionIndexObm];
        Screen.SetResolution(screenResolutionObm.width, screenResolutionObm.height, Screen.fullScreen);
    }
}
