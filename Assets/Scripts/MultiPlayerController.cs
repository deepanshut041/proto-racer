using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class MultiPlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 20.0f;
    [SerializeField] private float turnSpeed = 45.0f;

    private GameObject _gameController;
    private PlayerInput _playerInput;

    public string ControllerTag { get; set; }

    private void Start() {
        _gameController = GameObject.FindWithTag(ControllerTag);
        _playerInput = _gameController.GetComponent<PlayerInput>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            SceneManager.LoadScene("Main Menu", LoadSceneMode.Single);
        }
    }


    private void Update()
    {
        Vector2 move = _playerInput.actions["Move"].ReadValue<Vector2>();
        transform.Translate(move.y * speed * Time.deltaTime * Vector3.forward);
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * move.x);
    }
}
