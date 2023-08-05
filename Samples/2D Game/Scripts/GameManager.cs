using System.Collections;
using System.Collections.Generic;
using UnityEditor.Networking.PlayerConnection;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerMovement player;
    public Transform respawnPoint;
    public GameObject GameWonUI;
    // Start is called before the first frame update
    void Start()
    {
        player = FindAnyObjectByType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateSpawnPoint(Transform point)
    {
        respawnPoint = point;
    }
    public void Respawn()
    {
        player.transform.position = respawnPoint.position;
    }

    public void WinGame()
    {
        GameWonUI.SetActive(true);
    }
}
