using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelMenu : MonoBehaviour
{

    public Button[] buttons;

    private void Awake() {
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);

        for (int i = 0; i < buttons.Length; i++) {
            buttons[i].interactable = false;
        }

        for (int i = 0; i < unlockedLevel; i++) {
            buttons[i % buttons.Length].interactable = true;
        }
    }

    public void OpenMainMenu() {
        SceneManager.LoadScene("Player Selection", LoadSceneMode.Single);
    }

    public void OpenLevel(int levelId) {
        string levelName = "Level " + levelId;
        SceneManager.LoadScene(levelName, LoadSceneMode.Single);
    }
}
