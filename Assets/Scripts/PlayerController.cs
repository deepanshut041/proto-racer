using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 20.0f;
    [SerializeField] private float turnSpeed = 45.0f;

    private GameObject _gameController;
    private PlayerInput _playerInput;

    private void Start() {
        _gameController = GameObject.FindWithTag("GameController");
        _playerInput = _gameController.GetComponent<PlayerInput>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            string nextSceneName = GetNextSceneName(currentSceneName);

            if (!string.IsNullOrEmpty(nextSceneName))
            {
                SceneManager.LoadScene(nextSceneName, LoadSceneMode.Single);
                if (currentSceneName.StartsWith("Level "))
                {
                    int nextLevelId = int.Parse(currentSceneName["Level ".Length..]) + 1;
                    UnlockNewLevel(nextLevelId);
                }
            }
            else
            {
                SceneManager.LoadScene("Main Menu", LoadSceneMode.Single);
            }
        }
    }

    private string GetNextSceneName(string currentSceneName)
    {
        return currentSceneName switch
        {
            "Level 1" => "Level Menu",
            "Level 2" => "Level Menu",
            "Level 3" => "Level Menu",
            "Demo" => "Main Menu",
            _ => null,
        };
    }

    private void UnlockNewLevel(int levelId)
    {
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);
        if (levelId > unlockedLevel)
        {
            PlayerPrefs.SetInt("UnlockedLevel", levelId);
            PlayerPrefs.Save();
        }
    }

    private void Update()
    {
        Vector2 move = _playerInput.actions["Move"].ReadValue<Vector2>();
        transform.Translate(move.y * speed * Time.deltaTime * Vector3.forward);
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * move.x);
    }
}
