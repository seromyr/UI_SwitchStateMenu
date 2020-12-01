using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager main;

    [SerializeField]
    private State currentState;

    private bool switchUpdate;

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

        currentState = State.MainMenu;
        switchUpdate = true;
    }

    private void Update()
    {
        if (switchUpdate)
        {
            StateSwitchMachine();
        }
    }

    private void StateSwitchMachine()
    {
        MainCanvas.main.HideAll();
        switch (currentState)
        {
            case State.MainMenu:
                
                MainCanvas.main.ShowMainMenu(true);
                switchUpdate = false;
                break;
            case State.Gameplay:
                MainCanvas.main.ShowPauseMenu(false);
                switchUpdate = false;
                break;
            case State.Pause:
                MainCanvas.main.ShowPauseMenu(true);
                switchUpdate = false;
                break;
            case State.Options:
                MainCanvas.main.ShowOptionsMenu(true);
                switchUpdate = false;
                break;
            case State.GameOver:
                MainCanvas.main.ShowGameOver(true);
                switchUpdate = false;
                break;
            case State.QuitConfirm:
                MainCanvas.main.ShowQuitConfirmation(true);
                switchUpdate = false;
                break;
        }
    }

    public void GoToGameScreen()
    {
        SceneManager.LoadScene("Gameplay");
        switchUpdate = true;
        Time.timeScale = 1f;
        currentState = State.Gameplay;
    }

    public void OpenPauseMenu()
    {
        switchUpdate = true;
        Time.timeScale = 0f;
        currentState = State.Pause;
    }

    public void ResumeGameplay()
    {
        switchUpdate = true;
        Time.timeScale = 1f;
        currentState = State.Gameplay;
    }

    public void OpenOptions()
    {
        switchUpdate = true;
        currentState = State.Options;
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        switchUpdate = true;
        currentState = State.MainMenu;
    }

    public void OpenGameOverMenu()
    {
        switchUpdate = true;
        Time.timeScale = 0f;
        currentState = State.GameOver;
    }

    public void ShowConfirmQuit()
    {
        switchUpdate = true;
        currentState = State.QuitConfirm;
    }
}

[System.Serializable]
public enum State
{
    MainMenu,
    Gameplay,
    Pause,
    Options,
    GameOver,
    QuitConfirm
} 
