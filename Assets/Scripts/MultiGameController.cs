using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class MultiGameController : MonoBehaviour
{
    public GameObject[] players;
    public Transform spawnPoint;
    public int i;

    private void Awake()
    {
        int selectedPlayer = PlayerPrefs.GetInt("selectedPlayer", 0);
        GameObject prefab = players[selectedPlayer];
        GameObject clone = Instantiate(prefab, spawnPoint.position, Quaternion.identity);

        GameObject camera = GameObject.FindWithTag("MainCamera" + i);
        
        Rigidbody rigidbody= clone.AddComponent<Rigidbody>();
        rigidbody.mass = 1000f;

       
        camera.transform.SetParent(clone.transform);

        clone.AddComponent<MultiPlayerController>().ControllerTag = "GameController" + i;
    }
}
