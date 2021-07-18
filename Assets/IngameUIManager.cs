using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class IngameUIManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public Slider pointSlider;
    public TMP_Text pointsText;
    public GameObject buttonPauseMenu;
    public GameObject finishScreen;
    public GameObject pauseBackground;

    private int _points;
    // Start is called before the first frame update
    void Start()
    {
        _points = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddPoints(int value)
    {
        _points += value;
        RefreshUI();
    }

    private void RefreshUI()
    {
        pointSlider.value = (float)_points;
        pointsText.text = _points.ToString();
    }

    public void ShowPauseMenu(bool show)
    {
        pauseBackground.SetActive(show);
        buttonPauseMenu.SetActive(!show);
        pauseMenu.SetActive(show);
    }

    public void ShowEndscreen()
    {
        LeanTween.alpha(finishScreen.GetComponent<Image>().rectTransform, 255.0f, 1.0f).setEase(LeanTweenType.linear);
    }
}
