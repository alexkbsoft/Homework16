using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameStorage _gameStorage;
    [SerializeField] private TextMeshProUGUI _appleText;
    [SerializeField] private TextMeshProUGUI _collectedText;
    [SerializeField] private TextMeshProUGUI _killsText;
    [SerializeField] GameObject _finishScreen;
    [SerializeField] GameObject _endPopup;

    void Start()
    {
        _gameStorage.ApplesCount = 0;
        _gameStorage.KillCount = 0;

        EventBus.AddListener(EventConstants.COLLECTED, OnCollect);
        EventBus.AddListener(EventConstants.KILLED, OnKill);
        EventBus.AddListener(EventConstants.FINISH_REACHED, OnFinish);
    }

    private void OnCollect(CustomEvent ev)
    {
        _gameStorage.ApplesCount++;
        _appleText.text = $"{_gameStorage.ApplesCount}";
    }

    private void OnKill(CustomEvent ev)
    {
        _gameStorage.KillCount++;
    }
    private void OnFinish(CustomEvent ev)
    {
        _killsText.text = $"Убито: {_gameStorage.KillCount}";
        _collectedText.text = $"Собрано: {_gameStorage.ApplesCount}";

        if (_gameStorage.CurrentLevel < 4)
        {
            _finishScreen.SetActive(true);
        } else {
            _endPopup.SetActive(true);
        }
    }

    public void OnRestartClick()
    {
        SceneManager.LoadScene(_gameStorage.CurrentLevel);
    }

    public void OnMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void OnNextClick()
    {
        _gameStorage.CurrentLevel++;

        SceneManager.LoadScene(_gameStorage.CurrentLevel);
    }

    void OnDestroy()
    {
        EventBus.RemoveListener(EventConstants.COLLECTED, OnCollect);
        EventBus.RemoveListener(EventConstants.KILLED, OnKill);
        EventBus.RemoveListener(EventConstants.FINISH_REACHED, OnFinish);
    }
}
