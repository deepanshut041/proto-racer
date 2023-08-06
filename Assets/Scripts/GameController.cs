using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class GameController : MonoBehaviour
{
    public GameObject[] players;
    public Transform spawnPoint;

    private void Start()
    {
        int selectedPlayer = PlayerPrefs.GetInt("selectedPlayer", 0);
        GameObject prefab = players[selectedPlayer];
        GameObject clone = Instantiate(prefab, spawnPoint.position, Quaternion.identity);

        GameObject camera = GameObject.FindWithTag("MainCamera");

        Rigidbody rigidbody= clone.AddComponent<Rigidbody>();
        rigidbody.mass = 1000f;
        
        camera.transform.SetParent(clone.transform);

        clone.AddComponent<PlayerController>();
    }
}
