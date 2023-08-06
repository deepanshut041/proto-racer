using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    public void OpenDemo() {
        SceneManager.LoadScene("Demo", LoadSceneMode.Single);
    }

    public void OpenMultiPlayer() {
        SceneManager.LoadScene("Multi Player", LoadSceneMode.Single);
    }

    public void OpenLevelMenu() {
        SceneManager.LoadScene("Player Selection", LoadSceneMode.Single);
    }
}
