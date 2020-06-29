using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{
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

        gameResolutionDropdownObm.onValueChanged.AddListener(new UnityAction<int>(index =>
        {
            PlayerPrefs.SetInt(resNameObm, gameResolutionDropdownObm.value);
            PlayerPrefs.Save();
        }));
        qualityDropdownObm.onValueChanged.AddListener(new UnityAction<int>(index =>
        {
            PlayerPrefs.SetInt(qualityNameObm, qualityDropdownObm.value);
            PlayerPrefs.Save();
        }));
    }

    void Start ()
    {
        masterVolumeSliderObm.value = PlayerPrefs.GetFloat("masterVolumeObm", 1f);
        audioMixerObm.SetFloat("MasterVolumeObm", PlayerPrefs.GetFloat("masterVolumeObm"));

        sfxVolumeSliderObm.value = PlayerPrefs.GetFloat("sfxVolumeObm", 1f);
        audioMixerObm.SetFloat("SFXVolumeObm", PlayerPrefs.GetFloat("sfxVolumeObm"));

        musicVolumeSliderObm.value = PlayerPrefs.GetFloat("musicVolumeObm", 1f);
        audioMixerObm.SetFloat("MusicVolumeObm", PlayerPrefs.GetFloat("musicVolumeObm"));

        qualityDropdownObm.value = PlayerPrefs.GetInt(qualityNameObm, 3);

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
