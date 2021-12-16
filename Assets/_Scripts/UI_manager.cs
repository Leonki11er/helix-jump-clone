using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_manager : MonoBehaviour
{

    [SerializeField] private Text _currentLevelbarText;
    [SerializeField] private Text _nextLevelbarText;
    [SerializeField] private Text _currentLevelwinpanelText;
    [SerializeField] private Text _currentLevelprogress;
    [SerializeField] private Text _currentScore;
    [SerializeField] private Text _bestScore;
    [SerializeField] private Slider _currentLevelbar;
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private GameObject _WinPanel;
    [SerializeField] private GameObject _newRecord;
    [SerializeField] private Text _newRecordValue;
    private int _oldBestScore;

    public GameController GameController;



    private void Awake()
    {
        SetLevel(GameController.LevelIndex);
        SetCurrentScore(GameController.Score);
        SetBestScore(GameController.BestScore);
        _oldBestScore = GameController.BestScore;
    }


    public void SetLevel(int currentLevel)
    {
        _currentLevelbarText.text = (currentLevel + 1).ToString();
        _nextLevelbarText.text = (currentLevel+2).ToString();
        _currentLevelwinpanelText.text = (currentLevel + 1).ToString();
    }

    public void SetCurrentScore(int currentScore)
    {
        _currentScore.text = currentScore.ToString();
    }

    public void SetBestScore(int bestScore)
    {
        _bestScore.text = bestScore.ToString();
    }

    public void SetProgressBar(float currentProgress)
    {
        _currentLevelbar.value = currentProgress;
    }

    public void GameOver(float currentProgress)
    {
        _currentLevelprogress.text = (currentProgress * 1000).ToString();
        _gameOverPanel.SetActive(true);
        if(_oldBestScore < GameController.BestScore)
        {
            _newRecordValue.text = GameController.BestScore.ToString();
            _newRecord.SetActive(true);
        }
    }

    public void WinLevel()
    {
        _WinPanel.SetActive(true);
    }

    public void Restart()
    {
        SetCurrentScore(0);
        _gameOverPanel.SetActive(false);
    }

    public void NextLevel()
    {
        _WinPanel.SetActive(false);
        SetProgressBar(0f);
    }
}
