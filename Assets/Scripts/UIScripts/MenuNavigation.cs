using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenuNavigation : MonoBehaviour
{
    public GameObject currentPanel;
    public GameObject lastPanel;
    public GameObject backButton;
    public float animationSpeed = .35f;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < currentPanel.transform.parent.gameObject.transform.childCount; i++)
        {
            currentPanel.transform.parent.gameObject.transform.GetChild(i).gameObject.SetActive(false);
        }

        currentPanel.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GotoMenu(GameObject PanelToShow)
    {
        lastPanel = currentPanel;
        PanelToShow.transform.position = new Vector3(Screen.width * 2, PanelToShow.transform.position.y, PanelToShow.transform.position.z);

        LeanTween.moveX(currentPanel, currentPanel.transform.position.x - Screen.width, animationSpeed);

        PanelToShow.SetActive(true);
        currentPanel = PanelToShow;

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
        LeanTween.moveX(currentPanel, currentPanel.transform.position.x - Screen.width, animationSpeed);

        lastPanel.SetActive(true);
        currentPanel = lastPanel;

        LeanTween.moveX(lastPanel, Screen.width / 2, animationSpeed);
        ShowHideBackButton(false);
        lastPanel = null;
    }

    private void playMenusound()
    {

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
}
