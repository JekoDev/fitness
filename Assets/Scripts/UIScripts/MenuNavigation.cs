using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MenuNavigation : MonoBehaviour
{
    public GameObject registerPanel;
    public GameObject currentPanel;
    public GameObject lastPanel;
    public GameObject playerPanel;
    public GameObject backButton;
    public float animationSpeed = .35f;
    public PlayerManager playerManager;

    public Slider MusicVolumeSlider;
    public Slider SFXVolumeSlider;
    public TMP_InputField usernameinput;
    public TMP_Text TMP_Username;
    public TMP_Text TMP_Level;

    public Button buttonLanguageDE;
    public Button buttonLanguageEN;

    public AudioMixer MasterAudioMixer;


    // Start is called before the first frame update
    void Start()
    {
        DisableAllPanels();
        playerManager = new PlayerManager();

        if (playerManager.PlayerExists())
        {
            playerManager.LoadPlayer();
            InitGame();

        }
        else
        {
            playerPanel.SetActive(false);
            registerPanel.SetActive(true);
        }
    }

    private void InitGame()
    {
        TMP_Username.text = playerManager.Player.Username;
        TMP_Level.text = "Level " + playerManager.Player.Level;

        playerPanel.SetActive(true);

        currentPanel.SetActive(true);

        InitSettings();
    }

    private void DisableAllPanels()
    {
        for (int i = 0; i < currentPanel.transform.parent.gameObject.transform.childCount; i++)
        {
            currentPanel.transform.parent.gameObject.transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GotoMenu(GameObject PanelToShow)
    {
        lastPanel = currentPanel;

        if(!PanelToShow.name.Equals("Credits"))
            PanelToShow.transform.position = new Vector3(Screen.width * 2, PanelToShow.transform.position.y, PanelToShow.transform.position.z);


        LeanTween.moveX(currentPanel, currentPanel.transform.position.x - Screen.width, animationSpeed);

        PanelToShow.SetActive(true);
        currentPanel = PanelToShow;

        if (!PanelToShow.name.Equals("Credits"))
            LeanTween.moveX(PanelToShow, Screen.width / 2, animationSpeed);

        ShowHideBackButton(true);
    }

    public void ShowHideBackButton(bool show)
    {
        if (show)
        {
            backButton.SetActive(true);
            LeanTween.moveX(backButton, backButton.transform.position.x - (Screen.width * 0.1f), animationSpeed);
        }
        else
            LeanTween.moveX(backButton, backButton.transform.position.x + (Screen.width * 0.1f), animationSpeed);

    }

    public void GoBack()
    {
        if (currentPanel.name.Equals("Settings"))
            playerManager.SavePlayer();

        if (!currentPanel.name.Equals("Credits"))
            LeanTween.moveX(currentPanel, currentPanel.transform.position.x - Screen.width, animationSpeed);
        else
            currentPanel.transform.GetChild(0).GetComponent<ScaleInChildren>().Hide();

        lastPanel.SetActive(true);
        currentPanel = lastPanel;

        LeanTween.moveX(lastPanel, Screen.width / 2, animationSpeed);
        ShowHideBackButton(false);
        lastPanel = null;
    }


    public void QuitGame()
    {

#if UNITY_EDITOR
        // Application.Quit() does not work in the editor so
        // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }

    public void RegisterPlayer()
    {
        playerManager.CreatePlayer(usernameinput.text);

        registerPanel.SetActive(false);
        InitGame();

        playerManager.SavePlayer();
    }

    #region settings

    public void InitSettings()
    {
        MusicVolumeSlider.value = playerManager.Player.MusicVolume;
        SFXVolumeSlider.value = playerManager.Player.SFXVolume;

        InitLanguage();

    }

    private void InitLanguage()
    {
        switch (playerManager.Player.Langauge)
        {
            case 0:
                buttonLanguageDE.GetComponent<Image>().sprite = Resources.Load<Sprite>("icon_language_DE_active");
                buttonLanguageEN.GetComponent<Image>().sprite = Resources.Load<Sprite>("icon_language_EN_disabled");
                GetComponent<LocalizationHandler>().SetDE();
                break;
            case 1:
                buttonLanguageDE.GetComponent<Image>().sprite = Resources.Load<Sprite>("icon_language_DE_disabled");
                buttonLanguageEN.GetComponent<Image>().sprite = Resources.Load<Sprite>("icon_language_EN_active");
                GetComponent<LocalizationHandler>().SetEN();
                break;
            default:
                break;
        }


    }

    public void MusicVolumeSliderValueChange()
    {
        playerManager.SetMusicVolume(MusicVolumeSlider.value);
        MasterAudioMixer.SetFloat("MusicVol", playerManager.Player.MusicVolume);
    }
    
    public void SFXVolumeSliderValueChange()
    {
        playerManager.SetSFXVolume(SFXVolumeSlider.value);
        MasterAudioMixer.SetFloat("SFXVol", playerManager.Player.SFXVolume);

    }

    public void ButtonSetLanguage(int l)
    {
        switch (l)
        {
            case 0:
                playerManager.SetLanguage(Language.deDE);
                break;
            case 1:
                playerManager.SetLanguage(Language.enEN);
                break;
            default:
                break;
        }

        InitLanguage();

    }



    public void GotoScene(int s)
    {
        Debug.Log("GoTo Scene");
        SceneManager.LoadScene("PlayScene");
    }
    #endregion

}
