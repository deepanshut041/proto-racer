using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSelection : MonoBehaviour
{
    public GameObject[] players;
    public int selectedPlayer = 0;

    public void Start() {
        players[selectedPlayer].SetActive(true);
    }

    public void Update() {
        transform.Rotate(Vector3.up, Time.deltaTime * 45.0f );
    }

    public void StartGame() {
        PlayerPrefs.SetInt("selectedPlayer", selectedPlayer);
        SceneManager.LoadScene("Level Menu", LoadSceneMode.Single);
    }

    public void OpenMainMenu() {
        SceneManager.LoadScene("Main Menu", LoadSceneMode.Single);
    }

    public void NextPlayer() {
        players[selectedPlayer].SetActive(false);
        selectedPlayer = (selectedPlayer + 1) % players.Length;
        players[selectedPlayer].SetActive(true);
    }

    public void PreviousPlayer() {
        players[selectedPlayer].SetActive(false);
        selectedPlayer--;
        if (selectedPlayer < 0) {
            selectedPlayer += players.Length;
        }
        players[selectedPlayer].SetActive(true);
    }


}
