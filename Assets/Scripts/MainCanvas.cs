using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainCanvas : MonoBehaviour
{
    public static MainCanvas main;
    private Button playButon, pauseButton, resumeButton, optionsButton, quitButton, returnButton, dieButton, retryButton, noRetryButton, resumeSubButton, quitToMainSubButton;
    GameObject mainMenuGroup, pauseMenuGroup, gameplayGroup, optionsGroup, gameOverGroup, quitSubPanel;

    private void Awake()
    {
        if (main == null)
        {
            DontDestroyOnLoad(gameObject);
            main = this;
        }
        else if (main != this)
        {
            Destroy(gameObject);
        }

        GameObject.Find("PlayButton").TryGetComponent(out playButon);
        GameObject.Find("PauseButton").TryGetComponent(out pauseButton);
        GameObject.Find("ResumeButton").TryGetComponent(out resumeButton);
        GameObject.Find("OptionsButton").TryGetComponent(out optionsButton);
        GameObject.Find("QuitButton").TryGetComponent(out quitButton);
        GameObject.Find("ReturnButton").TryGetComponent(out returnButton);
        GameObject.Find("DieButton").TryGetComponent(out dieButton);
        GameObject.Find("PlayAgainButton").TryGetComponent(out retryButton);
        GameObject.Find("QuitToMainButton").TryGetComponent(out noRetryButton);
        GameObject.Find("ResumeSubButton").TryGetComponent(out resumeSubButton);
        GameObject.Find("QuitToMainSubButton").TryGetComponent(out quitToMainSubButton);

        mainMenuGroup  = GameObject.Find("MainMenu");
        pauseMenuGroup = GameObject.Find("PauseMenu");
        gameplayGroup  = GameObject.Find("Gameplay");
        optionsGroup   = GameObject.Find("OptionsMenu");
        gameOverGroup  = GameObject.Find("GameOver");
        quitSubPanel   = GameObject.Find("QuitSub");
    }

    private void Start()
    {
        playButon.onClick.AddListener(GameManager.main.GoToGameScreen);
        pauseButton.onClick.AddListener(GameManager.main.OpenPauseMenu);
        resumeButton.onClick.AddListener(GameManager.main.ResumeGameplay);
        optionsButton.onClick.AddListener(GameManager.main.OpenOptions);
        quitButton.onClick.AddListener(GameManager.main.ShowConfirmQuit);
        returnButton.onClick.AddListener(GameManager.main.OpenPauseMenu);
        dieButton.onClick.AddListener(GameManager.main.OpenGameOverMenu);
        retryButton.onClick.AddListener(GameManager.main.ResumeGameplay);
        noRetryButton.onClick.AddListener(GameManager.main.ReturnToMainMenu);
        resumeSubButton.onClick.AddListener(GameManager.main.ReturnToMainMenu);
        quitToMainSubButton.onClick.AddListener(GameManager.main.OpenPauseMenu); 
    }

    public void ShowMainMenu(bool value)
    {
        mainMenuGroup.SetActive(value);
    }

    public void ShowPauseMenu(bool value)
    {
        pauseMenuGroup.SetActive(value);
        gameplayGroup.SetActive(!value);
    }

    public void ShowOptionsMenu(bool value)
    {
        optionsGroup.SetActive(value);
    }

    public void ShowGameOver(bool value)
    {
        gameOverGroup.SetActive(value);
    }

    public void ShowQuitConfirmation(bool value)
    {
        quitSubPanel.SetActive(value);
    }

    public void HideAll()
    {
        mainMenuGroup.SetActive(false);
        pauseMenuGroup.SetActive(false);
        gameplayGroup.SetActive(false);
        optionsGroup.SetActive(false);
        gameOverGroup.SetActive(false);
        quitSubPanel.SetActive(false);
    }
}
