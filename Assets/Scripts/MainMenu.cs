using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameStorage _gameStorage;

    public void OnNewGame() {
        _gameStorage.CurrentLevel = 0;

        SceneManager.LoadScene(0);
    }
}
