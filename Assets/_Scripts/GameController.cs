using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public RotateLevelController RotateLevelController;
    public ParticleSystem[] WinPS;
    public enum State
    {
        Playing,
        Won,
        Loss,
    }

    public UI_manager uI_Manager;
    public ProgressBar ProgressBar;

    public State CurrentState { get; private set; }

    private const string LevelIndexKey = "LevelIndex";
    public int LevelIndex
    {
        get => PlayerPrefs.GetInt(LevelIndexKey, 0);
       private set
        {
            PlayerPrefs.SetInt(LevelIndexKey, value);
            PlayerPrefs.Save();
        }
    }

    private const string _score = "Score";
    public int Score
    {
        get => PlayerPrefs.GetInt(_score, 0);
        private set
        {
            PlayerPrefs.SetInt(_score, value);
            PlayerPrefs.Save();
        }
    }

    private const string _bestScore = "BestScore";
    public int BestScore
    {
        get => PlayerPrefs.GetInt(_bestScore, 0);
        private set
        {
            PlayerPrefs.SetInt(_bestScore, value);
            PlayerPrefs.Save();
        }
    }

    public void IncrementScore()
    {
        Score++;
        uI_Manager.SetCurrentScore(Score);
        if (Score > BestScore)
        {
            BestScore = Score;
            uI_Manager.SetBestScore(BestScore);
        }
    }
    public void NewGame()
    {
        ClearGameProgress();
        ReatartLevel();
    }

    public void ClearGameProgress()
    {
        PlayerPrefs.DeleteAll();
    }

    public void OnPlayerDied()
    {
        if (CurrentState != State.Playing) return;
        CurrentState = State.Loss;
        RotateLevelController.enabled = false;
        Score = 0;
        uI_Manager.GameOver(ProgressBar.CurrentProgress);
    }

    public void OnPlayerReachFinish()
    {
        if (CurrentState != State.Playing) return;
        CurrentState = State.Won;
        RotateLevelController.enabled = false;
        uI_Manager.SetLevel(LevelIndex);
        uI_Manager.WinLevel();
        for(int i = 0; i<WinPS.Length;i++)
        {
            WinPS[i].Play();
        }
    }
    public void NextLevel()
    {
        LevelIndex++;
        uI_Manager.NextLevel();
        ReloadLevel();
    }

    public void ReatartLevel()
    {
        uI_Manager.Restart();
        ReloadLevel();
    }

    private void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
