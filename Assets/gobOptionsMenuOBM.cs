using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gobOptionsMenuOBM : MonoBehaviour
{

    public AudioMixer audioMixerOBM;

    public Slider masterVolumeSliderOBM;

    public Slider sfxVolumeSliderOBM;

    public Slider musicVolumeSliderOBM;

    public Dropdown qualityDropdownOBM;

    public Dropdown gameResolutionDropdownOBM;

    public Toggle fullScreenToggleOBM;

    public Toggle gameControllerToggleOBM;

    private int screenIntOBM;

    private int controllerIntOBM;

    Resolution[] screenResolutionsOBM;

    private bool isFullScreenOBM = false;

    private bool useControllerOBM = false;

    const string qualityNameOBM = "qualityValueOBM";
    const string resNameOBM = "resolutionOptionOBM";

    void Awake()
    {
        screenIntOBM = PlayerPrefs.GetInt("toggleStateFullScreenOBM");

        if(screenIntOBM == 1)
        {
            isFullScreenOBM = true;
            fullScreenToggleOBM.isOn = true;
        }
        else
        {
            isFullScreenOBM = false;
            fullScreenToggleOBM.isOn = false;
        }

        controllerIntOBM = PlayerPrefs.GetInt("toggleStateControllerOBM");

        if (screenIntOBM == 1)
        {
            useControllerOBM = true;
            gameControllerToggleOBM.isOn = true;
        }
        else
        {
            useControllerOBM = false;
            gameControllerToggleOBM.isOn = false;
        }

        gameResolutionDropdownOBM.onValueChanged.AddListener(new UnityAction<int>(index =>
        {
            PlayerPrefs.SetInt(resNameOBM, gameResolutionDropdownOBM.value);
            PlayerPrefs.Save();
        }));
        qualityDropdownOBM.onValueChanged.AddListener(new UnityAction<int>(index =>
        {
            PlayerPrefs.SetInt(qualityNameOBM, qualityDropdownOBM.value);
            PlayerPrefs.Save();
        }));
    }

    void Start ()
    {
        masterVolumeSliderOBM.value = PlayerPrefs.GetFloat("masterVolumeOBM", 1f);
        audioMixerOBM.SetFloat("MasterVolumeOBM", PlayerPrefs.GetFloat("masterVolumeOBM"));

        sfxVolumeSliderOBM.value = PlayerPrefs.GetFloat("sfxVolumeOBM", 1f);
        audioMixerOBM.SetFloat("SFXVolumeOBM", PlayerPrefs.GetFloat("sfxVolumeOBM"));

        musicVolumeSliderOBM.value = PlayerPrefs.GetFloat("musicVolumeOBM", 1f);
        audioMixerOBM.SetFloat("MusicVolumeOBM", PlayerPrefs.GetFloat("musicVolumeOBM"));

        qualityDropdownOBM.value = PlayerPrefs.GetInt(qualityNameOBM, 3);

        screenResolutionsOBM = Screen.resolutions;

        gameResolutionDropdownOBM.ClearOptions();

        List<string> resolutionOptionsOBM = new List<string>();

        int currentGameResolutionIndex = 0;
        for (int i = 0; i < screenResolutionsOBM.Length; i++)
        {
            string resolutionOptionOBM = screenResolutionsOBM[i].width + " x " + screenResolutionsOBM[i].height + " " + screenResolutionsOBM[i].refreshRate + "Hz";
            resolutionOptionsOBM.Add(resolutionOptionOBM);

            if (screenResolutionsOBM[i].width == Screen.currentResolution.width &&
                screenResolutionsOBM[i].height == Screen.currentResolution.height &&
                screenResolutionsOBM[i].refreshRate == Screen.currentResolution.refreshRate)
            {
                currentGameResolutionIndex = i;
            }
        }

        gameResolutionDropdownOBM.AddOptions(resolutionOptionsOBM);
        gameResolutionDropdownOBM.value = PlayerPrefs.GetInt(resNameOBM, currentGameResolutionIndex);
        gameResolutionDropdownOBM.RefreshShownValue();
    }

    public void SetMasterVolumeOBM (float gameMasterVolumeOBM)
    {
        PlayerPrefs.SetFloat("masterVolumeOBM", gameMasterVolumeOBM);
        audioMixerOBM.SetFloat("MasterVolumeOBM", PlayerPrefs.GetFloat("masterVolumeOBM"));
    }

    public void SetSFXVolumeOBM(float gameSFXVolumeOBM)
    {
        PlayerPrefs.SetFloat("sfxVolumeOBM", gameSFXVolumeOBM);
        audioMixerOBM.SetFloat("SFXVolumeOBM", PlayerPrefs.GetFloat("sfxVolumeOBM"));
    }

    public void SetMusicVolumeOBM(float gameMusicVolumeOBM)
    {
        PlayerPrefs.SetFloat("musicVolumeOBM", gameMusicVolumeOBM);
        audioMixerOBM.SetFloat("MusicVolumeOBM", PlayerPrefs.GetFloat("musicVolumeOBM"));
    }

    public void SetQualityOBM (int gameQualityIndexOBM)
    {
        QualitySettings.SetQualityLevel(gameQualityIndexOBM);
    }

    public void SetGameFullscreenOBM (bool gameIsFullscreenOBM)
    {
        Screen.fullScreen = gameIsFullscreenOBM;

        if (gameIsFullscreenOBM == false)
        {
            isFullScreenOBM = false;
            PlayerPrefs.SetInt("toggleStateFullScreenOBM", 0);
        }
        else
        {
            isFullScreenOBM = true;
            PlayerPrefs.SetInt("toggleStateFullScreenOBM", 1);
        }
    }

    public void SetControllerOBM(bool gameControllerOBM)
    {

        if (gameControllerOBM == false)
        {
            useControllerOBM = false;
            PlayerPrefs.SetInt("toggleStateControllerOBM", 0);
        }
        else
        {
            useControllerOBM = true;
            PlayerPrefs.SetInt("toggleStateControllerOBM", 1);
        }
    }

    public void SetGameResolutionOBM (int gameResolutionIndexOBM)
    {
        Resolution screenResolutionOBM = screenResolutionsOBM[gameResolutionIndexOBM];
        Screen.SetResolution(screenResolutionOBM.width, screenResolutionOBM.height, Screen.fullScreen);
    }
}
