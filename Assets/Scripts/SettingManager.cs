using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class SettingManager : MonoBehaviour 
{
	//SAVE BUTTON
	//public Button applyButton;
	//GRAPHICS OPTIONS
	public Toggle fullscreenToggle;
	public Dropdown resolutionDropdown;
	public Dropdown textureQualityDropdown;
	public Dropdown AaDropdown;
	public Dropdown vSyncDropdown;
	public Resolution[] resolutions;
	public GameSettings gameSettings;
    public Toggle bloomToggle;
    public Toggle paaToggle;
    public Toggle aoToggle;
    public Toggle tmToggle;
    //EXIT MENU
    //public Canvas quitMenu;
	//public Button exitText;
	//public Button YesButton;
	//public Button NoButton;
	//OPTIONS MENU
	//public Canvas OptionsMenu;
	//public Canvas GraphicsMenu;
	//public Canvas AudioMenu;
	//public Canvas GameplayMenu;
	//public Button optionsbutton;
	//public Button graphicsButton;
	//public Button audioButton;
	//public Button gameplayButton;
	//AUDIO OPTIONS
	//public Slider musicVolumeSlider;
	public Slider masterVolumeSlider;
	//public AudioSource musicSource;

    private UnityEngine.PostProcessing.PostProcessingBehaviour postProcessingbehaviour;
    private UnityEngine.PostProcessing.PostProcessingProfile profile;

    void OnEnable()
	{
        gameSettings = new GameSettings ();
		fullscreenToggle.onValueChanged.AddListener(delegate { OnFullscreenToggle(); });
		resolutionDropdown.onValueChanged.AddListener(delegate { OnResolutionChange(); });
		textureQualityDropdown.onValueChanged.AddListener(delegate {OnTextureQualityChange ();});
		AaDropdown.onValueChanged.AddListener(delegate {OnAaChange ();});
		vSyncDropdown.onValueChanged.AddListener(delegate {OnVsyncChange ();});
		//applyButton.onClick.AddListener (delegate {OnApplyButtonClick (clicked:true);});
        bloomToggle.onValueChanged.AddListener(delegate { OnBloomToggle(); });
        paaToggle.onValueChanged.AddListener(delegate { OnPaaToggle(); });
        aoToggle.onValueChanged.AddListener(delegate { OnAoToggle(); });
        tmToggle.onValueChanged.AddListener(delegate { OnTmToggle(); });
        //exitText.onClick.AddListener (delegate {OnExitClick (clicked:true);});
        //optionsbutton.onClick.AddListener (delegate {OnOptionsClick (clicked:true);});
        //YesButton.onClick.AddListener (delegate {OnYesClick (clicked: true);});
        //NoButton.onClick.AddListener (delegate {NoPress ();});
        //graphicsButton.onClick.AddListener (delegate {OnGraphicsClick (clicked: true);});
        //audioButton.onClick.AddListener (delegate {OnAudioClick (clicked: true);});
        //musicVolumeSlider.onValueChanged.AddListener (delegate { OnMusicVolumeChange();});
        masterVolumeSlider.onValueChanged.AddListener(delegate { OnMasterVolumeChange(); });

        resolutions = Screen.resolutions;
		foreach (Resolution resolution in resolutions) 
		{
			resolutionDropdown.options.Add(new Dropdown.OptionData(resolution.ToString()));
		}

		//EXIT SCRIPT:
		/*
		quitMenu = quitMenu.GetComponent<Canvas> ();
		exitText = exitText.GetComponent<Button> ();
		quitMenu.enabled = false;*/
	}

    void Start()
    {
        postProcessingbehaviour = Camera.main.GetComponent<UnityEngine.PostProcessing.PostProcessingBehaviour>();
        profile = postProcessingbehaviour.profile;
    }

    public void OnFullscreenToggle()
	{
		gameSettings.fullscreen = Screen.fullScreen = fullscreenToggle.isOn;

	}

    public void OnBloomToggle()
    {
        gameSettings.bloom = profile.bloom.enabled = bloomToggle.isOn;
    }

    public void OnPaaToggle()
    {
        gameSettings.paa = profile.antialiasing.enabled = paaToggle.isOn;
    }

    public void OnAoToggle()
    {
        gameSettings.ao = profile.ambientOcclusion.enabled = aoToggle.isOn;
    }

    public void OnTmToggle()
    {
        gameSettings.tm = profile.colorGrading.enabled = tmToggle.isOn;
    }

    public void OnResolutionChange()
	{
		Screen.SetResolution (resolutions [resolutionDropdown.value].width, resolutions [resolutionDropdown.value].height, Screen.fullScreen);
		gameSettings.resolutionIndex = resolutionDropdown.value;
	}
	public void OnTextureQualityChange()
	{
		QualitySettings.masterTextureLimit = gameSettings.textureQuality = textureQualityDropdown.value;
	}
	public void OnAaChange()
	{
		//0=0 1=2x 2=4x 3=8X
		QualitySettings.antiAliasing = gameSettings.Aa = (int)Mathf.Pow(2f, AaDropdown.value);
	}
	public void OnVsyncChange()
	{
		//0 1=60 2=30
		QualitySettings.vSyncCount = gameSettings.vSync = vSyncDropdown.value;
	}

	public void SaveSettings()
	{
		string jsonData = JsonUtility.ToJson (gameSettings, true);
		File.WriteAllText (Application.persistentDataPath + "/gamesettings.json", jsonData);
	}
	public void LoadSettings()
	{
		gameSettings = JsonUtility.FromJson<GameSettings>(File.ReadAllText(Application.persistentDataPath + "/gamesettings.json"));

		//TEST:
		/*jsonData = File.ReadAllText(Application.persistentDataPath + "/gamesettings.json");
		gameSettings = JsonUtility.FromJson<GameSettings>(jsonData);﻿*/

		AaDropdown.value = gameSettings.Aa;
		vSyncDropdown.value = gameSettings.vSync;
		textureQualityDropdown.value = gameSettings.textureQuality;
		resolutionDropdown.value = gameSettings.resolutionIndex;
		fullscreenToggle.isOn = gameSettings.fullscreen;
		resolutionDropdown.RefreshShownValue();
		Screen.fullScreen = gameSettings.fullscreen;
	}

	//EXITMENU: YES BUTTON 
	public void OnYesClick(bool clicked)
	{ if (clicked == true) {
			ExitGame ();
		}
	}

	public void OnMasterVolumeChange()
	{
		AudioListener.volume = gameSettings.masterVolume = masterVolumeSlider.value;
	}

	public void ExitGame()
	{
		Application.Quit ();
	}
}
